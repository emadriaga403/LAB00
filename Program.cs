using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LAB0
{
    class Program
    {
        static void Main()
        {
            double low = GetAndValidateInput("Enter the low number:"); // get and validate low number
            double high = GetAndValidateInput("Enter the high number:", low); // get and validate high number

            // array that holds numbers low to high, +1 determines number of elements
            double[] numbers = Enumerable.Range((int)low, (int)(high - low + 1)).Select(i => (double)i).ToArray();

            double difference = numbers.Max() - numbers.Min();
            Console.WriteLine($"The difference between the highest and lowest number is: {difference}");

            // reverse array
            Array.Reverse(numbers);

            // create a new file
            using (FileStream fs = File.Create("numbers.txt"))
            {
                // write to file
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (double number in numbers)
                    {
                        sw.WriteLine(number);
                    }
                }
            }

            // read from file and print sum
            double sum = File.ReadLines("numbers.txt").Select(double.Parse).Sum();
            Console.WriteLine($"the sum of numbers is: {sum}");

            // print prime numbers
            Console.WriteLine("prime numbers below v");
            foreach (double number in numbers)
            {
                if (IsPrime(number))
                {
                    Console.WriteLine(number);
                }
            }
        }

        //validate
        static double GetAndValidateInput(string message, double minValue = 1)
        {
            //variable to hold input
            double value;
            do
            {
                //msg
                Console.WriteLine(message);
                //parse 2 double
                value = double.Parse(Console.ReadLine());
                //repeat if <1
            } while (value < minValue);
            //return input
            return value;
        }

        //prime number method
        static bool IsPrime(double number)
        {
            //less than 2 not prime
            if (number < 2)
            {
                return false;
            }

            //loop from 2 to sqrt of number
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                //if divisable by any number in loop it is not prime
                if (number % i == 0)
                {
                    return false;
                }
            }

            //=prime
            return true;
        }
    }
}