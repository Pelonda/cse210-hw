using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity helps you relax by breathing slowly.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        int time = 0;
        while (time < _duration)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(4);
            Console.Write("\nBreathe out... ");
            ShowCountDown(4);
            time += 8;
        }

        DisplayEndingMessage();
    }
}