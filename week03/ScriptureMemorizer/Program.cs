using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Extra credit
        // a scripture 
       
        List<(Reference reference, string text)> scriptures = new List<(Reference, string)>
        {
            (new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding."),
            (new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son."),
            (new Reference("Alma", 32, 21),
                "And now as I said concerning faith faith is not to have a perfect knowledge of things.")
        };

        Random random = new Random();
        var selected = scriptures[random.Next(scriptures.Count)];
        Scripture scripture = new Scripture(selected.reference, selected.text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine();
            Console.Write("Press Enter to continue or type quit: ");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}