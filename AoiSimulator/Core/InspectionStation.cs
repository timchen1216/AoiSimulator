using System.Drawing;
using AoiSimulator.Devices;
using AoiSimulator.Inspection;
using AoiSimulator.Models;

namespace AoiSimulator.Core;

// 事件要傳出去的資料：這次的影像和檢測結果
public class InspectionCompletedEventArgs : EventArgs
{
    public Bitmap Image { get; }
    public InspectionResult Result { get; }

    public InspectionCompletedEventArgs(Bitmap image, InspectionResult result)
    {
        Image = image;
        Result = result;
    }
}

public class InspectionStation
{
    private readonly ICamera _camera;
    private readonly IInspector _inspector;

    // 統計數據：外面可以讀，只有自己能改
    public int TotalCount { get; private set; }
    public int NgCount { get; private set; }
    public double Yield => TotalCount == 0 ? 0 : (double)(TotalCount - NgCount) / TotalCount;

    // 事件：檢測完成時通知訂閱者
    public event EventHandler<InspectionCompletedEventArgs>? InspectionCompleted;

    public InspectionStation(ICamera camera, IInspector inspector)
    {
        _camera = camera;
        _inspector = inspector;
    }

    private CancellationTokenSource? _cts;

    public MachineState State { get; private set; } = MachineState.Idle;
    public event EventHandler<MachineState>? StateChanged;

    public void Start(int intervalMs = 500)
    {
        if (State == MachineState.Running) return;

        _cts = new CancellationTokenSource();
        var token = _cts.Token;
        SetState(MachineState.Running);

        // 把檢測迴圈丟到背景執行緒
        Task.Run(async () =>
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    RunOnce();
                    await Task.Delay(intervalMs);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"檢測迴圈發生錯誤：{ex.Message}");
                SetState(MachineState.Error);
            }
        });
    }

    public void Stop()
    {
        if (State != MachineState.Running) return;

        _cts?.Cancel();
        SetState(MachineState.Idle);
    }

    private void SetState(MachineState newState)
    {
        State = newState;
        StateChanged?.Invoke(this, newState);
    }

    public void RunOnce()
    {
        var image = _camera.Capture();
        var result = _inspector.Inspect(image);

        // TODO：更新 TotalCount 和 NgCount
        TotalCount++;
        if(result.Verdict == Verdict.NG)
        {
            NgCount++;
        }

        // 發出事件，通知所有訂閱者
        InspectionCompleted?.Invoke(this, new InspectionCompletedEventArgs(image, result));
    }
}