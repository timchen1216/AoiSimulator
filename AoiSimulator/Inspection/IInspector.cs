using System.Drawing;
using AoiSimulator.Models;

namespace AoiSimulator.Inspection;

public interface IInspector
{
    string Name { get; }
    InspectionResult Inspect(Bitmap image);
}