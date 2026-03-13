using System;

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator generator = new PromptGenerator();
        Journal journal = new Journal();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nJournal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    WriteEntry(generator, journal);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose 1-5.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void WriteEntry(PromptGenerator generator, Journal journal)
    {
        string prompt = generator.GetRandomPrompt();
        Console.WriteLine("Prompt:");
        Console.WriteLine(prompt);
        Console.WriteLine();

        Console.Write("Your response: ");
        string response = Console.ReadLine();

        // Use short date string per spec (store as string)
        string dateText = DateTime.Now.ToShortDateString();

        Entry e = new Entry(dateText, prompt, response);
        journal.AddEntry(e);
        Console.WriteLine("Entry added to journal.");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save (e.g. journal.txt): ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename.");
            return;
        }
        journal.SaveToFile(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load (e.g. journal.txt): ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename.");
            return;
        }
        journal.LoadFromFile(filename);
    }
}