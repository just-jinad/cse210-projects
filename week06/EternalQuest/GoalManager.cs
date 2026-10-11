namespace EternalQuest;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public GoalManager()
    {
    }

    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu:");
            Console.WriteLine("  1. Create new goal");
            Console.WriteLine("  2. List goals");
            Console.WriteLine("  3. Save goals");
            Console.WriteLine("  4. Load goals");
            Console.WriteLine("  5. Record event");
            Console.WriteLine("  6. Quit");
            choice = ReadText("Select a choice: ");

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoalDetails();
            else if (choice == "3") SaveGoals();
            else if (choice == "4") LoadGoals();
            else if (choice == "5") RecordEvent();
            else if (choice != "6") Console.WriteLine("Invalid choice.");
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points. Level {GetLevel()}");
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
        Console.WriteLine("\nYour goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nGoal types:");
        Console.WriteLine("  1. Simple goal");
        Console.WriteLine("  2. Eternal goal");
        Console.WriteLine("  3. Checklist goal");
        Console.WriteLine("  4. Streak goal (daily habit)");
        string type = ReadText("Which type? ");

        if (type != "1" && type != "2" && type != "3" && type != "4")
        {
            Console.WriteLine("Invalid type.");
            return;
        }

        string name = ReadText("Name: ");
        string description = ReadText("Description: ");
        int points = ReadNumber("Points: ");

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            int target = ReadNumber("Times needed to complete: ");
            int bonus = ReadNumber("Bonus points on completion: ");
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            _goals.Add(new StreakGoal(name, description, points));
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        Console.WriteLine("\nYour goals:");
        ListGoalNames();
        int number = ReadNumber("Which goal did you do? ");
        if (number < 1 || number > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int oldLevel = GetLevel();
        int earned = _goals[number - 1].RecordEvent();
        _score += earned;

        Console.WriteLine($"You earned {earned} points!");
        if (GetLevel() > oldLevel)
        {
            Console.WriteLine($"*** LEVEL UP! You are now level {GetLevel()} ***");
        }
    }

    public void SaveGoals()
    {
        string file = ReadText("File name: ");
        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Saved.");
    }

    public void LoadGoals()
    {
        string file = ReadText("File name: ");
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(file);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] p = lines[i].Split('|');

            if (p[0] == "SimpleGoal")
                _goals.Add(new SimpleGoal(p[1], p[2], int.Parse(p[3]), bool.Parse(p[4])));
            else if (p[0] == "EternalGoal")
                _goals.Add(new EternalGoal(p[1], p[2], int.Parse(p[3])));
            else if (p[0] == "ChecklistGoal")
                _goals.Add(new ChecklistGoal(p[1], p[2], int.Parse(p[3]), int.Parse(p[4]), int.Parse(p[5]), int.Parse(p[6])));
            else if (p[0] == "StreakGoal")
                _goals.Add(new StreakGoal(p[1], p[2], int.Parse(p[3]), int.Parse(p[4]), DateTime.Parse(p[5])));
        }
        Console.WriteLine("Loaded.");
    }

    // Every 1000 points is a new level (never below level 1).
    private int GetLevel() => Math.Max(0, _score) / 1000 + 1;

    // '|' is our save-file separator, so it can't appear in user text.
    private string ReadText(string prompt)
    {
        Console.Write(prompt);
        return (Console.ReadLine() ?? "").Replace("|", "/");
    }

    private int ReadNumber(string prompt)
    {
        int number;
        while (!int.TryParse(ReadText(prompt), out number))
        {
            Console.WriteLine("Please enter a whole number.");
        }
        return number;
    }
}