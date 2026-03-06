using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Collect numbers
        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        // Sum Compute
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        // Average Compute
        double average = (double)sum / numbers.Count;

        // Largest number
        int max = numbers[0];
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }

        // Find the smallest number
        int smallest = int.MaxValue;
        foreach (int num in numbers)
        {
            if (num > 0 && num < smallest)
            {
                smallest = num;
            }
        }

        // Sort 
        numbers.Sort();

        // Results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {smallest}");

        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}