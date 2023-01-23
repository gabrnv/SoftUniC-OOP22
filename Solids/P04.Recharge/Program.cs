namespace P04.Recharge
{
    using System;

    class Program
    {
        static void Main()
        {
            Employee em001 = new Employee("Boby");
            Robot robcho = new Robot("r2d2", 100);
            robcho.Recharge();
            robcho.Work(20);
            robcho.Work(81);
        }
    }
}
