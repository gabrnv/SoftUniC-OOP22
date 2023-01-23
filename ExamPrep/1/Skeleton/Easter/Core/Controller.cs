using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;
            if(bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if(bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
            bunnies.Add(bunny);
            return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IDye dye = new Dye(power);
            if(bunnies.FindByName(bunnyName) != null)
            {
                bunnies.FindByName(bunnyName).AddDye(dye);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            return String.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return String.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = eggs.FindByName(eggName);
            List<IBunny> selected = bunnies.Models.Where(x => x.Energy >= 50).ToList();
            if(selected.Count > 0)
            {
                foreach(IBunny bunny in selected)
                {
                    while(bunny.Energy > 0 && egg.EnergyRequired > 0)
                    {
                        egg.GetColored();
                        bunny.Work();
                    }
                    if(bunny.Energy == 0)
                    {
                        bunnies.Remove(bunny);
                    }
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            if(egg.EnergyRequired > 0)
            {
                return String.Format(OutputMessages.EggIsNotDone, egg.Name);
            }
            else
            {
                return String.Format(OutputMessages.EggIsDone, egg.Name);

            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{eggs.Models.Where(x => x.EnergyRequired == 0).ToList().Count} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach(var model in bunnies.Models)
            {
                sb.AppendLine($"Name: {model.Name}");
                sb.AppendLine($"Energy: {model.Energy}");
                sb.AppendLine($"Dyes: {model.Dyes.Count} not finished");
            }

            return sb.ToString().Trim();
        }
    }
}
