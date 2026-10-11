namespace EternalQuest;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    
    public override void RecordEvent() { }

    // Never completes by design.
    public override bool IsComplete() => false;

    public override string GetStringRepresentation()
        => $"{nameof(EternalGoal)}|{_shortName}|{_description}|{_points}";
}