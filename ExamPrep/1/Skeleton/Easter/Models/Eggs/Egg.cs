﻿using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;
        private int reqEnergy;

        public Egg(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }
                name = value;
            }
        }

        public int EnergyRequired
        {
            get
            {
                return reqEnergy;
            }
            set
            {
                reqEnergy = value;
                if(reqEnergy < 0)
                {
                    reqEnergy = 0;
                }
            }
        }

        public void GetColored()
        {
            EnergyRequired -= 10;
        }

        public bool IsDone() => EnergyRequired == 0;

    }
}
