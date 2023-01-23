using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;
        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                else
                {
                    name = value;
                }
            }
        }

        public int Capacity { get; set; }

        public double EquipmentWeight
        {
            get
            {
                double sum = 0;
                foreach (var item in Equipment)
                {
                    sum += item.Weight;
                }
                return sum;
            }
        }
        public ICollection<IEquipment> Equipment { get
            { 
                return equipment;
            }
        }

        public ICollection<IAthlete> Athletes
        {
            get
            {
                return athletes;
            }
        }

        public void AddAthlete(IAthlete athlete)
        {
            if(athletes.Count < Capacity)
            {
                athletes.Add(athlete);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughSize);
            }
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach(var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} is a {GetType().Name}:");
            if(Athletes.Count > 0)
            {
                _ = sb.AppendLine($"Athletes: {string.Join(", ", Athletes.Select(x => x.FullName))}");
            }
            else
            {
                sb.AppendLine($"Athletes: No athletes");
            }
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");
            return sb.ToString().Trim();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return athletes.Remove(athlete);
        }
    }
}
