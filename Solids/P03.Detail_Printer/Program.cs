using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Employee em01 = new Employee("Bob");
            Supervisor em02 = new Supervisor("John");
            Manager em03 = new Manager("Ted", new List<string>(){"fries", "tenders", "burgers"});
            DetailsPrinter printer = new DetailsPrinter(new List<IWorker>() { em01, em02, em03});
            printer.PrintDetails();
        }
    }
}
