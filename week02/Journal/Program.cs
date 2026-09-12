using System;
using System.IO;

public class Program
{
    public static Journal _journal = new Journal();
    public static PromptGenerator _promptGenerator = new PromptGenerator();

    static void Main(string[] args)
    {
        Run();
    }

    public static void Run()
    {
        string choice = "";
        while (choice != "5")
        {
            DisplayMenu();
            choice = Console.ReadLine();

            if (choice == "1")
            {
                WriteEntry();
            }
            else if (choice == "2")
            {
                _journal.Display();
            }
            else if (choice == "3")
            {
                Console.Write("Enter the filename: ");
                string filename = Console.ReadLine();
                _journal.SaveToFile(filename);
                Console.WriteLine("Journal saved successfully.");
            }
            else if (choice == "4")
            {
                Console.Write("Enter the filename: ");
                string filename = Console.ReadLine();
                try
                {
                    _journal.LoadFromFile(filename);
                    Console.WriteLine("Journal loaded successfully.");
                    _journal.Display();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found. Please check the filename and try again.");
                }
            }
            else if (choice != "5")
            {
                Console.WriteLine("Invalid choice.");
            }
        }

    }

    public static void DisplayMenu()
    {
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Quit");
        Console.Write("Please select a choice: ");
    }

    public static void WriteEntry()
    {
        string prompt = _promptGenerator.GetRandomPrompt();

        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        string DateNow = DateTime.Now.ToShortDateString();

        Entry entry = new Entry
        {
            _date = DateNow,
            _prompt = prompt,
            _response = response
        };

        _journal.AddEntry(entry);
    }

   

   
}