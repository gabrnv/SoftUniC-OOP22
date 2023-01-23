using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favFood) : base(name, favFood)
        {

        }
        public override string ExplainSelf()
        {
            return $"I am {name} and my fovourite food is {favouriteFood} {Environment.NewLine}DJAAF";
        }
    }
}
