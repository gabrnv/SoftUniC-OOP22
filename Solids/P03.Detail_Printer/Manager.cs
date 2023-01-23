using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : IWorker
    {
        public Manager(string name, List<string> documents) : base(name)
        {
            this.Documents = documents;
            this.Name = name;
        }

        public List<string> Documents { get; set; }

        public override void Print()
        {
            Console.WriteLine(this.Name);
            Console.WriteLine(string.Join(Environment.NewLine, Documents));
        }
    }
}
