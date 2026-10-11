namespace EternalQuest;

public class StreakGoal : Goal
{
    private const int MaxMultiplier = 5;
    private int _streak;
    private DateTime _lastDone;

    public StreakGoal(string name, string description, int points, int streak = 0, DateTime? lastDone = null)
        : base(name, description, points)
    {
        _streak = streak;
        _lastDone = lastDone ?? DateTime.MinValue;
    }

    // A streak only counts if you did it today or yesterday.
    private int CurrentStreak()
    {
        bool alive = _lastDone.Date == DateTime.Today || _lastDone.Date == DateTime.Today.AddDays(-1);
        return alive ? _streak : 0;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0; // once per day
        }

        _streak = CurrentStreak() + 1;
        _lastDone = DateTime.Today;
        return Points * Math.Min(_streak, MaxMultiplier);
    }

    public override bool IsComplete() => _lastDone.Date == DateTime.Today;

    public override string GetDetailsString()
        => $"{base.GetDetailsString()} -- Streak: {CurrentStreak()} day(s)";

    public override string GetStringRepresentation()
        => $"StreakGoal|{ShortName}|{Description}|{Points}|{_streak}|{_lastDone:yyyy-MM-dd}";
}