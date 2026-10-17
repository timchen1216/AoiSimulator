using System.Drawing;
using AoiSimulator.Models;

namespace AoiSimulator.Inspection;

public class ThresholdInspector : IInspector
{
    private readonly int _threshold;
    private readonly int _maxDefectPixels;

    public string Name => "Threshold";

    public ThresholdInspector(int threshold = 100, int maxDefectPixels = 5)
    {
        _threshold = threshold;
        _maxDefectPixels = maxDefectPixels;
    }

    public InspectionResult Inspect(Bitmap image)
    {
        int defectCount = 0;

        // TODO 1：走訪每個像素，亮度低於 _threshold 就 defectCount++
        for (int y=0; y<image.Height; y++)
        {
            for (int x=0; x<image.Height; x++)
            {
                if (image.GetPixel(x, y).R < _threshold)
                {
                    defectCount++;
                }
            }
        }

        // TODO 2：defectCount 大於 _maxDefectPixels 判 NG，否則 OK，回傳結果
        Verdict verdict = defectCount > _maxDefectPixels ? Verdict.NG : Verdict.OK;
        return new InspectionResult(verdict, defectCount, Name);

    }
}