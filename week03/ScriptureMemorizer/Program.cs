using System;

// Extra feature: a different scripture is selected randomly each time the program starts.
class Program
{
    static void Main(string[] args)
    {
        Reference[] references =
        {
            new Reference("John", 3, 16),
            new Reference("Philippians", 4, 13),
            new Reference("Psalm", 23, 1),
            new Reference("Proverbs", 3, 5, 6),
            new Reference("Isaiah", 41, 10)
        };

        string[] scriptureTexts =
        {
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.",
            "I can do all things through Christ which strengtheneth me.",
            "The LORD is my shepherd; I shall not want.",
            "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.",
            "Fear thou not; for I am with thee: be not dismayed; for I am thy God: I will strengthen thee; yea, I will help thee; yea, I will uphold thee with the right hand of my righteousness."
        };

        Random random = new Random();
        int scriptureIndex = random.Next(references.Length);
        Scripture scripture = new Scripture(references[scriptureIndex], scriptureTexts[scriptureIndex]);

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