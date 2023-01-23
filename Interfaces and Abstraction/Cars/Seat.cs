using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    internal class Seat : ICar
    {
        public Seat(string model, string color)
        {
            this.Color = color;
            this.Model = model;
        }
        public override string Start()
        {
            throw new NotImplementedException();
        }

        public override string Stop()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Color} Seat {Model}";
        }
    }
}
