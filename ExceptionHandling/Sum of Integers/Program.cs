using System;

namespace Sum_of_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            string[] input = Console.ReadLine().Split();
            for (int i = 0; i < input.Length; i++)
            {
                int num = 0;
                long longNum = 0;
                try
                {
                    longNum = long.Parse(input[i]);
                    num = int.Parse(input[i]);
                    sum += num;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"The element '{num}' is in wrong format!");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"The element '{longNum}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{longNum}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
