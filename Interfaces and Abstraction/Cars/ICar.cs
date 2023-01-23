using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public abstract class ICar
    {
        public string Model;
        public string Color;

        public abstract string Start();
        public abstract string Stop();
    }
}
