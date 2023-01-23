using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core.Contracts
{
    public class Controller : IController
    {
        // try interface
        private EquipmentRepository equipment;
        private ICollection<IGym> gyms;
        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            if (athleteType == "Boxer")
            {
                if(gym.GetType().Name == "BoxingGym")
                {
                    IAthlete athlete = new Boxer(athleteName, motivation, numberOfMedals);
                    gym.AddAthlete(athlete);
                }
                else
                {
                    return "The gym is not appropriate.";
                }
            }
            else if(athleteType == "Weightlifter")
            {
                if (gym.GetType().Name == "WeightliftingGym")
                {
                    IAthlete athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                    gym.AddAthlete(athlete);
                }
                else
                {
                    return "The gym is not appropriate.";
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == "BoxingGloves")
            {
                equipment.Add(new BoxingGloves());
                return $"Successfully added {equipmentType}.";
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment.Add(new Kettlebell());
                return $"Successfully added {equipmentType}.";
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
        }

        public string AddGym(string gymType, string gymName)
        {
            if(gymType == "BoxingGym")
            {
                gyms.Add(new BoxingGym(gymName));
                return $"Successfully added {gymType}.";
            }
            else if(gymType == "WeightliftingGym")
            {
                gyms.Add(new WeightliftingGym(gymName));
                return $"Successfully added {gymType}.";
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            return $"The total weight of the equipment in the gym {gymName} is {gym.EquipmentWeight:f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            if(equipment.FindByType(equipmentType) != null)
            {
                gyms.FirstOrDefault(x => x.Name == gymName).AddEquipment(equipment.FindByType(equipmentType));
                equipment.Remove(equipment.FindByType(equipmentType));
                return $"Successfully added { equipmentType} to { gymName}.";
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var gym in gyms)
            {
                //sb.Append
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            int count = 0;
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            foreach (var athlete in gym.Athletes)
            {
                athlete.Exercise();

                count++;
            }
            return $"Exercise athletes: {count}.";
        }
    }
}
