namespace AoiSimulator.Models;

public enum Verdict { OK, NG }

public enum MachineState { Idle, Running, Paused, Error }

public class InspectionResult
{
    public Verdict Verdict { get; }
    public int DefectPixelCount { get; }
    public string InspectorName { get; }

    public InspectionResult(Verdict verdict, int defectPixelCount, string inspectorName)
    {
        Verdict = verdict;
        DefectPixelCount = defectPixelCount;
        InspectorName = inspectorName;
    }
}