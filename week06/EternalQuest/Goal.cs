namespace EternalQuest;

/// <summary>
/// Base type for all goals. Subclasses decide what "recording an event" and
/// "complete" mean; the base owns the shared state and the display contract.
/// </summary>
public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points; // UML says string; int is correct, we do math on it.

    protected Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string ShortName => _shortName;

    /// <summary>Points earned by a single recorded event (excludes bonuses).</summary>
    public int Points => _points;

    public abstract void RecordEvent();
    public abstract bool IsComplete();

    /// <summary>Line shown in the goal list, e.g. "[X] Run (Daily cardio)".</summary>
    public virtual string GetDetailsString()
        => $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description})";

    /// <summary>Serialized form used by GoalManager.SaveGoals / LoadGoals.</summary>
    public abstract string GetStringRepresentation();
}