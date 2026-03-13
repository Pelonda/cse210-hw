using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public Journal()
    {
    }

    // Add an Entry 
    public void AddEntry(Entry newEntry)
    {
        if (newEntry != null)
        {
            _entries.Add(newEntry);
        }
    }

    // Display all entries 
    public void DisplayAll()
    {
        Console.WriteLine("Journal Entries:");
        Console.WriteLine(new string('=', 40));
        foreach (Entry e in _entries)
        {
            e.Display();
        }
    }

    // Save the journal to a simple text file.
    
    public void SaveToFile(string file)
    {
        List<string> lines = new List<string>();
        foreach (Entry e in _entries)
        {
            lines.Add(e._date ?? "");
            lines.Add(e._promptText ?? "");
            lines.Add(e._entryText ?? "");
            lines.Add("---"); // separator
        }
        File.WriteAllLines(file, lines);
    }

    // Load a journal from the simple text format written above.
    
    public void LoadFromFile(string file)
    {
        _entries.Clear();
        if (!File.Exists(file))
        {
            return;
        }

        string[] lines = File.ReadAllLines(file);
        for (int i = 0; i < lines.Length; )
        {
            // Expecting: date, prompt, entry, separator
            string date = (i < lines.Length) ? lines[i++] : "";
            string prompt = (i < lines.Length) ? lines[i++] : "";
            string entryText = (i < lines.Length) ? lines[i++] : "";
            // consume separator if present
            if (i < lines.Length && lines[i] == "---") i++;

            Entry e = new Entry(date, prompt, entryText);
            _entries.Add(e);
        }
    }
}