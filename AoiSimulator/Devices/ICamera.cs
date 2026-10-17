using System.Drawing;

namespace AoiSimulator.Devices;

public interface ICamera
{
    string Name { get; }
    Bitmap Capture();
}