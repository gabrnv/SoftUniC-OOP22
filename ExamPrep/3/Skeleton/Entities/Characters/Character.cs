using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
	    // try private sets
	    
	    private string name;
	    private double health;
	    private double armor;

	    public Character(string name, double health, double armor, double abilityPoints, Bag bag)
	    {
		    Name = name;
		    BaseHealth = health;
		    Health = health;
		    BaseArmor = armor;
		    Armor = armor;
		    AbilityPoints = abilityPoints;
		    this.Bag = bag;
	    }
		// TODO: Implement the rest of the class.
		public string Name
		{
			get
			{
				return name;
			}
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
				}

				name = value;
			}
		}

		public double BaseHealth { get; private set; }

		public double Health
		{
			get
			{
				return health;
			}
			set
			{
				health = value;
				if (health > BaseHealth)
				{
					health = BaseHealth;
				}

				if (health < 0)
				{
					health = 0;
				}
			}
		}

		public double BaseArmor { get; private set; }

		public double Armor
		{
			get
			{
				return armor;
			}
			set
			{
				armor = value;
				if (armor > BaseArmor)
				{
					armor = BaseArmor;
				}

				if (armor < 0)
				{
					armor = 0;
				}
			}
		}

		public double AbilityPoints { get; private set; }
		public Bag Bag { get; private set; }
		public bool IsAlive { get; set; } = true;

		public void TakeDamage(double hitPoints)
		{
			//health = 100
			//armor = 30
			//hitPoints = 40
			
			double usedHits = 0;
			if (IsAlive)
			{
				if (armor > hitPoints)
				{
					armor -= hitPoints;
				}
				else if(armor == hitPoints)
				{
					armor = 0;
				}
				else
				{
					hitPoints -= armor; 
					armor = 0;
					health -= hitPoints;
					if (health <= 0)
					{
						IsAlive = false;
					}
				}
			}
		}

		public void UseItem(Item item)
		{
			if (IsAlive)
			{
				item.AffectCharacter(this);
			}
		}
		
		
		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}