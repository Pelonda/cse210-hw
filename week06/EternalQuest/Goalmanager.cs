using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalNames();
            }
            else if (choice == "3")
            {
                ListGoalDetails();
            }
            else if (choice == "4")
            {
                RecordEvent();
            }
            else if (choice == "5")
            {
                SaveGoals();
            }
            else if (choice == "6")
            {
                LoadGoals();
            }
            else if (choice == "7")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Score: {_score}   Rank: {GetRank()}");
        Console.WriteLine();
    }

    public void ListGoalNames()
    {
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string goalType = Console.ReadLine();

        string shortName = ReadString("What is the name of your goal? ");
        string description = ReadString("What is a short description of it? ");
        int points = ReadInt("What is the amount of points associated with this goal? ");

        if (goalType == "1")
        {
            _goals.Add(new SimpleGoal(shortName, description, points));
        }
        else if (goalType == "2")
        {
            _goals.Add(new EternalGoal(shortName, description, points));
        }
        else if (goalType == "3")
        {
            int target = ReadInt("How many times does this goal need to be accomplished for a bonus? ");
            int bonus = ReadInt("What is the bonus for accomplishing it that many times? ");
            _goals.Add(new ChecklistGoal(shortName, description, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        ListGoalDetails();
        int choice = ReadInt("Which goal did you accomplish? ");
        int index = choice - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int pointsEarned = _goals[index].RecordEvent();
        _score += pointsEarned;

        Console.WriteLine($"You earned {pointsEarned} points!");
    }

    public void SaveGoals()
    {
        string filename = ReadString("What is the filename for the goal file? ");

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Score|{_score}");

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        string filename = ReadString("What is the filename for the goal file? ");

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        _score = 0;

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            if (line.StartsWith("Score|"))
            {
                string[] scoreParts = line.Split('|');
                if (scoreParts.Length > 1 && int.TryParse(scoreParts[1], out int loadedScore))
                {
                    _score = loadedScore;
                }
            }
            else
            {
                Goal goal = CreateGoalFromString(line);
                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    private Goal CreateGoalFromString(string line)
    {
        string[] parts = line.Split('|');
        string type = parts[0];

        if (type == "SimpleGoal" && parts.Length >= 5)
        {
            string shortName = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            bool isComplete = bool.Parse(parts[4]);
            return new SimpleGoal(shortName, description, points, isComplete);
        }
        else if (type == "EternalGoal" && parts.Length >= 4)
        {
            string shortName = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            return new EternalGoal(shortName, description, points);
        }
        else if (type == "ChecklistGoal" && parts.Length >= 7)
        {
            string shortName = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            int amountCompleted = int.Parse(parts[4]);
            int target = int.Parse(parts[5]);
            int bonus = int.Parse(parts[6]);
            return new ChecklistGoal(shortName, description, points, amountCompleted, target, bonus);
        }

        return null;
    }

    private int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int value))
            {
                return value;
            }

            Console.WriteLine("Please enter a valid number.");
        }
    }

    private string ReadString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? "";
    }

    private string GetRank()
    {
        if (_score >= 3000)
        {
            return "Quest Master";
        }
        else if (_score >= 1500)
        {
            return "Champion";
        }
        else if (_score >= 500)
        {
            return "Achiever";
        }

        return "Rookie";
    }
}