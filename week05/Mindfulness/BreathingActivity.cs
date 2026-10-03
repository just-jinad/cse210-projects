using System;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int breathSeconds = 4;
        bool breatheIn = true;
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            if (breatheIn)
            {
                Console.Write("Breathe in... ");
            }
            else
            {
                Console.Write("Now breathe out... ");
            }

            ShowCountDown(breathSeconds);
            Console.WriteLine();
            breatheIn = !breatheIn;
        }

        DisplayEndingMessage();
    }
}