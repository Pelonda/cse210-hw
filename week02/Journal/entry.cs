using System;

public class Entry
{
    // Member 
    public string _date = "";
    public string _promptText = "";
    public string _entryText = "";

    // Constructors
    public Entry() { }

    public Entry(string date, string prompt, string text)
    {
        _date = date;
        _promptText = prompt;
        _entryText = text;
    }

    // Display the entry
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine(new string('-', 40));
    }
}