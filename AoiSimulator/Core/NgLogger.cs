using AoiSimulator.Models;

namespace AoiSimulator.Core;

public class NgLogger
{
    private readonly string _logPath;

    public NgLogger(string logPath)
    {
        _logPath = logPath;
    }

    public void OnInspectionCompleted(object? sender, InspectionCompletedEventArgs e)
    {
        // TODO：如果結果是 NG，寫一行記錄到檔案
        //   時間：DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        //   寫入檔案（附加在最後一行）：File.AppendAllText(_logPath, 內容 + Environment.NewLine);
        //   內容建議包含：時間、檢測器名稱、缺陷像素數
        if (e.Result.Verdict == Verdict.NG)
        {
            string line = $"Time:{DateTime.Now:yyyy-MM-dd HH:mm:ss}, Inspector:{e.Result.InspectorName}, DefectPixels:{e.Result.DefectPixelCount}";
            File.AppendAllText(_logPath, line + Environment.NewLine);
        }
    }


}