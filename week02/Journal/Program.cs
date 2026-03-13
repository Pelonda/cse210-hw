using System;

class Program
{
    static void Main(string[] args)
    {
        // Create prompt generator and journal
        PromptGenerator pg = new PromptGenerator();
        Journal myJournal = new Journal();

        // Create two example entries using generator
        Entry e1 = new Entry();
        e1._date = DateTime.Now.ToString("yyyy-MM-dd");
        e1._promptText = pg.GetRandomPrompt();
        e1._entryText = "Today I started the journal project and wrote some sample text.";

        Entry e2 = new Entry(DateTime.Now.ToString("yyyy-MM-dd"), pg.GetRandomPrompt(),
                             "Second sample entry showing how the journal holds entries.");

        // Add entries to the journal
        myJournal.AddEntry(e1);
        myJournal.AddEntry(e2);

        // Display all entries
        myJournal.DisplayAll();

        // Save to file (example file in working directory)
        string filename = "journal_data.txt";
        myJournal.SaveToFile(filename);
        Console.WriteLine($"Saved journal to {filename}");

        // Clear and reload to demonstrate LoadFromFile
        myJournal = new Journal();
        myJournal.LoadFromFile(filename);
        Console.WriteLine("Reloaded journal from file:");
        myJournal.DisplayAll();

        // Pause (optional)
        // Console.WriteLine("Press any key to exit...");
        // Console.ReadKey();
    }
}