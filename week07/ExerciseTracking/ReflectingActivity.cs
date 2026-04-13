using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time you overcame a challenge.",
        "Think of a time you helped someone.",
        "Think of a time you did something difficult."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful?",
        "What did you learn from it?",
        "How did you feel afterward?"
    };

    private Random _random = new Random();

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description = "This activity helps you reflect on your strengths.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"\n{prompt}");
        ShowSpinner(3);

        int time = 0;
        while (time < _duration)
        {
            string question = _questions[_random.Next(_questions.Count)];
            Console.WriteLine($"\n{question}");
            ShowSpinner(4);
            time += 4;
        }

        DisplayEndingMessage();
    }
}