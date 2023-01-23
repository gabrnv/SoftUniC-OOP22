using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    internal class Employee : IWorker
    {
        public Employee(string name) : base(name)
        {
            this.Name = name;
        }

    }
}
