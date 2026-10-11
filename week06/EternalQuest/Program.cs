using System;
using EternalQuest;

// EXCEEDING REQUIREMENTS
// 1. Levels: every 1000 points raises the player's level. The level shows next
//    to the score, and a "LEVEL UP" message appears when one is gained.
// 2. StreakGoal: a fourth goal type for daily habits. Recording it on
//    consecutive days builds a streak that multiplies the points (up to x5).
//    Missing a day resets the streak, and it can only be recorded once a day.
// 3. Small safeguards: finished simple/checklist goals can't be farmed for
//    points, and number input is validated instead of crashing.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}