using System;

class Program
{
    static void Main(string[] args)
    {
        // Extra credit:
        // I added extra prompts and questions to make the activities feel less repetitive.
        // I also track how many activities were completed during the session and show that
        // summary when the user quits.

        int completedActivities = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
                completedActivities++;
            }
            else if (choice == "2")
            {
                ReflectingActivity activity = new ReflectingActivity();
                activity.Run();
                completedActivities++;
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
                completedActivities++;
            }
            else if (choice == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }

            Console.WriteLine();
            Console.Write("Press Enter to return to the menu...");
            Console.ReadLine();
        }

        Console.Clear();
        Console.WriteLine("Thank you for using the Mindfulness Program.");
        Console.WriteLine($"You completed {completedActivities} activity(ies) this session.");
    }
}