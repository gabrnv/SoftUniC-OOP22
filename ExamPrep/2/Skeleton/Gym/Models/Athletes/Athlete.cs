using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int stamina;
        private int numberOfMedals;

        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            FullName = fullName;
            Motivation = motivation;
            Stamina = stamina;
            NumberOfMedals = numberOfMedals;
        }

        public string FullName
        {
            get{
                return fullName;
            }
            set{

                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentNullException(ExceptionMessages.InvalidAthleteName);
                    }
                    else
                    {
                        fullName = value;
                    }

                
            }
        }

        public string Motivation
        {
            get
            {
                return motivation;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAthleteMotivation);
                }
                else
                {
                    motivation = value;
                }
            }
        }

        public int Stamina
        {
            get
            {
                return stamina;
            }
            set
            {
                stamina = value;
                if(stamina > 100)
                {
                    stamina = 100;
                    throw new ArgumentException(ExceptionMessages.InvalidStamina);
                }
            }
        }

        public int NumberOfMedals
        {
            get
            {
                return numberOfMedals;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAthleteMedals);
                }
                else
                {
                    numberOfMedals = value;
                }
            }
        }

        public abstract void Exercise();
    }
}
