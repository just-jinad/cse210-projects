namespace EternalQuest;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted)
        : this(name, description, points, target, bonus)
    {
        _amountCompleted = amountCompleted;
    }

    
    public int Bonus => _bonus;

    public override void RecordEvent()
    {
        if (!IsComplete())
        {
            _amountCompleted++;
        }
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
        => $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}";

    public override string GetStringRepresentation()
        => $"{nameof(ChecklistGoal)}|{_shortName}|{_description}|{_points}|{_bonus}|{_target}|{_amountCompleted}";
}