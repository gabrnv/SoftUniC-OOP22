using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        protected Animal(string name, string favFood)
        {
            this.name = name;
            this.favouriteFood = favFood;
        }
        public string name { get; protected set; }
        public string favouriteFood { get; protected set; }

        public abstract string ExplainSelf();
    }
}
