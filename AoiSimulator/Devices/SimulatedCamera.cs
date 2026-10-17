using System.Drawing;

namespace AoiSimulator.Devices;

public class SimulatedCamera : ICamera
{
    private readonly Random _rng = new();
    private readonly double _defectRate;

    public string Name => "SimCam-01";

    public SimulatedCamera(double defectRate = 0.3)
    {
        _defectRate = defectRate;
    }

    public Bitmap Capture()
    {
        const int size = 200;
        var bmp = new Bitmap(size, size);

        using (var g = Graphics.FromImage(bmp))
        {
            g.Clear(Color.FromArgb(180, 180, 180));
            if (_rng.NextDouble() < _defectRate)
                DrawDefect(g, size);
        }

        // 加一點雜訊，讓影像比較像真的
        for (int i = 0; i < 500; i++)
        {
            int x = _rng.Next(size), y = _rng.Next(size);
            if (bmp.GetPixel(x, y).R > 100)   // 不覆蓋缺陷
            {
                int v = _rng.Next(150, 210);
                bmp.SetPixel(x, y, Color.FromArgb(v, v, v));
            }
        }
        return bmp;
    }

    private void DrawDefect(Graphics g, int size)
    {
        if (_rng.Next(2) == 0)
        {
            // 黑點
            using var brush = new SolidBrush(Color.FromArgb(40, 40, 40));
            int r = _rng.Next(4, 12);
            g.FillEllipse(brush, _rng.Next(10, size - 30), _rng.Next(10, size - 30), r, r);
        }
        else
        {
            // 刮痕
            using var pen = new Pen(Color.FromArgb(50, 50, 50), 2);
            g.DrawLine(pen, _rng.Next(size), _rng.Next(size), _rng.Next(size), _rng.Next(size));
        }
    }
}