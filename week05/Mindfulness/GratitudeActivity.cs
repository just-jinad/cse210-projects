using System;
using System.Collections.Generic;

class GratitudeActivity : Activity
{
    private readonly List<string> _responses = new List<string>();

    public GratitudeActivity() : base(
        "Gratitude",
        "This activity will help you focus on the blessings in your life by writing down things you are grateful for.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        CollectResponses();

        Console.WriteLine();
        Console.WriteLine($"You recorded {_responses.Count} things you are grateful for.");
        DisplayEndingMessage();
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("Think of something you are grateful for and write it down.");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
    }

    private void CollectResponses()
    {
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
            {
                _responses.Add(response);
            }
        }
    }
}
