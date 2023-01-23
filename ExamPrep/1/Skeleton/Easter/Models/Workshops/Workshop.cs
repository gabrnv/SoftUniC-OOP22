using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny) //////////////
        {
            List<IDye> bunnyDyes = bunny.Dyes.Where(x => x.Power > 0).ToList();
            foreach(var dye in bunnyDyes)
            {
                while(dye.Power > 0)
                { 
                    while(bunny.Energy > 0 && bunnyDyes.Count > 0 && egg.EnergyRequired > 0)
                    {
                        egg.GetColored();
                    }
                }
            }
        }
    }
}
