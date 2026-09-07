using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
        Random randomGenerator = new Random();
        int randomNumber = randomGenerator.Next(1, 101);
        Console.WriteLine(randomNumber);

        Console.WriteLine("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        while (randomNumber != magicNumber)
        {
            if (randomNumber > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (randomNumber < magicNumber)
            {
                Console.WriteLine("Higher");
            }

            Console.WriteLine("What is your guess? ");
            magicNumber = int.Parse(Console.ReadLine());

            if (randomNumber == magicNumber)
            {
                Console.WriteLine("You guessed it!");
            }
        }

    }
}