using System;

class Program
{
    static void Main(string[] args)
    {
        // magic number
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        // first guess
        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());

        // Loop till the guess is correct
        while (guess != magicNumber)
        {
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }

            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("u guessed it!");
    }
}