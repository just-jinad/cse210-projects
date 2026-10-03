using System;
using System.Collections.Generic;
using System.Threading;

class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    // FIX: frames allocated once per instance, not on every spinner call
    private readonly List<string> _spinnerFrames = new List<string> { "|", "/", "-", "\\" };

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        // FIX: no stray leading space, no double period (descriptions already end with one)
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        int duration;
        Console.Write("How long, in seconds, would you like for your session? ");
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.Write("Enter a whole number greater than 0: ");
        }
        _duration = duration;

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int index = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(_spinnerFrames[index]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            index = (index + 1) % _spinnerFrames.Count;
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string number = i.ToString();
            Console.Write(number);
            Thread.Sleep(1000);

            // FIX: erase every character written, so 10 -> 9 leaves no ghost "1"
            for (int j = 0; j < number.Length; j++)
            {
                Console.Write("\b \b");
            }
        }
    }
}