using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5);
        Scripture scripture = new Scripture(reference, "Trust in the Lord with all your heart and lean not on your own understanding.");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("Press enter to continue, or type 'quit' to end the program.");
            string input = Console.ReadLine() ?? "";

            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}