using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>();
    private Random _rand = new Random();

    public PromptGenerator()
    {
        // Example starter prompts 
        _prompts.Add("What made you smile today?");
        _prompts.Add("Describe a challenge you faced this week.");
        _prompts.Add("What are you grateful for right now?");
    }

    // Returns a random prompt
    public string GetRandomPrompt()
    {
        if (_prompts == null || _prompts.Count == 0)
        {
            return "";
        }
        int i = _rand.Next(_prompts.Count);
        return _prompts[i];
    }
}