using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> models;
        public EquipmentRepository()
        {
            models = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models
        {
            get
            {
                return this.models.AsReadOnly();
            }
        }

        public void Add(IEquipment model)
        {
            models.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            return models.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(IEquipment model)
        {
            return models.Remove(model);
        }
    }
}
