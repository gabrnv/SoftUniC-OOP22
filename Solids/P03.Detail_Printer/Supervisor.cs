using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    internal class Supervisor : IWorker
    {
        public Supervisor(string name) : base(name)
        {
            this.Name = name;
        }

        public override void Print()
        {
            Console.WriteLine("WORK BETTER AND FASTER AAAA");
        }
    }
}
