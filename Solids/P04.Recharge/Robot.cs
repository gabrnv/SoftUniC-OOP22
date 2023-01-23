using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Recharge
{
    public class Robot : Worker, IRechargeable
    {
        private int capacity;
        private int currentPower;

        public Robot(string id, int capacity) : base(id)
        {
            this.capacity = capacity;
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public int CurrentPower
        {
            get { return this.currentPower; }
            set { this.currentPower = value; }
        }

        public override void Work(int hours)
        {
            if (hours <= this.currentPower)
            {
                base.Work(hours);
                this.currentPower -= hours;
                Console.WriteLine("BIBU 0100110 JOb");
            }
            else
            {
                Console.WriteLine("Battery: 0");
                Console.WriteLine("Recharging...");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Battery: {i*10}");
                }
                Recharge();
            }
        }

        public void Recharge()
        {
            this.currentPower = this.capacity;
            Console.WriteLine("Battery: 100");
        }


    }
}