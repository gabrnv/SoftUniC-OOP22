using System;
using System.Collections.Generic;
namespace Enter_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
             HashSet<int> arr = new HashSet<int>();
             int previusNumber = 1;
             for (int i = 0; i < 10; i++)
             {
                try
                {
                    int number = int.Parse(Console.ReadLine());
                    if(number <= previusNumber)
                    {
                        Console.WriteLine($"Your number is not in range {previusNumber} - 100!");
                        i--;
                    }
                    else
                    {
                        arr.Add(number);
                        previusNumber = number;
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Invalid Number!");
                    i--;
                }
             }
            Console.WriteLine(String.Join(", ", arr).Trim());
        }
    }
}
