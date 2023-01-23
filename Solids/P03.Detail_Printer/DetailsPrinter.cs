using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<IWorker> employees;

        public DetailsPrinter(IList<IWorker> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (IWorker worker in this.employees)
            {
                worker.Print();
            }
        }

    }
}
