using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    internal class Tesla : IElectronicCar
    {
        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
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
            return $"{Color} Tesla {Model} with {Battery} Batteries";
        }
    }
}
