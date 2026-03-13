using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>();
    private Random _rand = new Random();

    public PromptGenerator()
    {
        // At least five prompts as required 
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
        // Extra 
        _prompts.Add("What small win did I have today?");
        _prompts.Add("What am I grateful for right now?");
    }

    // Returns a random prompt.
    public string GetRandomPrompt()
    {
        if (_prompts == null || _prompts.Count == 0) return "";
        int i = _rand.Next(_prompts.Count);
        return _prompts[i];
    }
}