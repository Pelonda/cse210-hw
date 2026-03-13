using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // List of entries 
    public List<Entry> _entries = new List<Entry>();

    public Journal() { }

    // AddEntry encapsulates 
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
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries to show.");
            return;
        }

        Console.WriteLine("Journal Entries:");
        Console.WriteLine(new string('=', 40));
        foreach (Entry e in _entries)
        {
            e.Display();
        }
    }

    // ---ENTRY---
    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry e in _entries)
                {
                    writer.WriteLine(e._date ?? "");
                    writer.WriteLine(e._promptText ?? "");
                    writer.WriteLine(e._entryText ?? "");
                    writer.WriteLine("---ENTRY---");
                }
            }
            Console.WriteLine($"Journal saved to '{filename}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    // Load from file produced above.
    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            for (int i = 0; i < lines.Length; )
            {
                string date = (i < lines.Length) ? lines[i++] : "";
                string prompt = (i < lines.Length) ? lines[i++] : "";
                string entryText = (i < lines.Length) ? lines[i++] : "";

                // Consume separator line.
                if (i < lines.Length && lines[i] == "---ENTRY---") i++;

                Entry e = new Entry(date, prompt, entryText);
                _entries.Add(e);
            }
            Console.WriteLine($"Loaded {_entries.Count} entries from '{filename}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }
}