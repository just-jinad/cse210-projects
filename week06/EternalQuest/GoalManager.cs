namespace EternalQuest;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        // TODO: menu loop -> Display player info, list, create, save, load, record, quit.
        throw new NotImplementedException();
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }
    }

    public void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        // TODO: prompt for type + fields, validate ints with int.TryParse, add to _goals.
        throw new NotImplementedException();
    }

    public void RecordEvent()
    {
        // TODO: pick goal, call RecordEvent(), add Points to _score.
        // Checklist: also add Bonus when the event flips IsComplete() false -> true.
        throw new NotImplementedException();
    }

    public void SaveGoals()
    {
        // TODO: line 1 = _score, then one GetStringRepresentation() per goal.
        throw new NotImplementedException();
    }

    public void LoadGoals()
    {
        // TODO: read file, parse score, split on '|', switch on type tag to rebuild goals.
        throw new NotImplementedException();
    }
}