using System;

class Program
{
    static void Main(string[] args)
    {
        // Extra credit: I added a score-based rank system (Rookie, Achiever, Champion, Quest Master)
        // so the program gives the user a fun progression feature beyond the core requirements.

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}