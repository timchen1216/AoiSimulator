using AoiSimulator.Core;
using AoiSimulator.Devices;
using AoiSimulator.Inspection;
using AoiSimulator.Models;
namespace AoiSimulator
{
    public partial class Form1 : Form
    {
        private readonly InspectionStation _station;

        public Form1()
        {
            InitializeComponent();

            _station = new InspectionStation(new SimulatedCamera(), new ThresholdInspector());
            _station.InspectionCompleted += Station_InspectionCompleted;   // 訂閱事件
            var logger = new NgLogger("ng_log.txt");
            _station.InspectionCompleted += logger.OnInspectionCompleted;
            _station.StateChanged += (s, state) => BeginInvoke(new Action(() =>
            {
                lblState.Text = $"狀態：{state}";
                btnStart.Enabled = state != MachineState.Running;
                btnCapture.Enabled = state != MachineState.Running;
                btnStop.Enabled = state == MachineState.Running;
            }));
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            _station.RunOnce();
        }

        // 事件發生時會被呼叫的方法
        private void Station_InspectionCompleted(object? sender, InspectionCompletedEventArgs e)
        {

            // 如果目前不在 UI 執行緒，就請 UI 執行緒來執行這個方法
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Station_InspectionCompleted(sender, e)));
                return;
            }

            pictureBox1.Image?.Dispose();
            pictureBox1.Image = e.Image;
            lblResult.Text = $"{e.Result.Verdict}（缺陷像素：{e.Result.DefectPixelCount}）";
            lblResult.ForeColor = e.Result.Verdict == Verdict.OK ? Color.Green : Color.Red;
            lblStats.Text = $"總數 {_station.TotalCount}　NG {_station.NgCount}　良率 {_station.Yield:P1}";
        }

        private void lblStats_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _station.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _station.Stop();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _station.Stop();
            base.OnFormClosing(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
