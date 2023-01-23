using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party;
		private List<Item> pool;
		public WarController()
		{
			party = new List<Character>();
			pool = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			Character character = null;
			if (characterType == "Warrior")
			{
				character = new Warrior(name);
			}
			else if (characterType == "Priest")
			{
				character = new Warrior(name);
			}
			else
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}
			party.Add(character);
			return string.Format(SuccessMessages.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
		{
			string name = args[0];
			Item item = null;

			if (name == "FirePotion")
			{
				item = new FirePotion();
			}
			else if (name == "HealthPotion")
			{
				item = new HealthPotion();
			}
			else
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, name));
			}
			pool.Add(item);
			return string.Format(SuccessMessages.AddItemToPool, name);
		}

		public string PickUpItem(string[] args)
		{
			string name = args[0];
			Character character = party.FirstOrDefault(x => x.Name == name);
			if (character == null)
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, name);
			}

			if (!pool.Any())
			{
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
			}

			Item item = pool.Last();
			character.Bag.AddItem(item);
			pool.Remove(pool.Last());
			return String.Format(SuccessMessages.PickUpItem,name,item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];
			Character character = party.FirstOrDefault(x => x.Name == characterName);
			if (character == null)
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, characterName);
			}
			Item item = character.Bag.GetItem(itemName);
			character.UseItem(item);
			return string.Format(SuccessMessages.UsedItem, character.Name, itemName);
		}

		public string GetStats()
		{
			List<Character> sortedByIsAlive = party.Where(x => x.IsAlive).ToList();
			List<Character> sortedByHealth = party.OrderByDescending(x => x.Health).ToList();
			StringBuilder sb = new StringBuilder();
			foreach (var character in sortedByHealth)
			{
				sb.AppendLine(
					$"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: ");
				if (character.IsAlive)
				{
					sb.Append("Alive");
				}
				else
				{
					sb.Append("Dead");
				}

				sb.AppendLine();
			}

			return sb.ToString().Trim();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string recieverName = args[1];

			Character attacker = party.FirstOrDefault(x => x.Name == attackerName);
			Character reciever = party.FirstOrDefault(x => x.Name == recieverName);

			if (attacker == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}
			if (reciever == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, recieverName));
			}

			if (attacker.GetType().Name != "Warrior")
			{
				throw new ArgumentException(ExceptionMessages.AttackFail, attackerName);
			}
			
			reciever.TakeDamage(attacker.AbilityPoints);

			StringBuilder sb = new StringBuilder();

			sb.AppendLine(
				$"{attackerName} attacks {recieverName} for {attacker.AbilityPoints} hit points! {recieverName} has {reciever.Health}/{reciever.BaseHealth} HP and {reciever.Armor}/{reciever.BaseArmor} AP left!");
			if (!reciever.IsAlive)
			{
				sb.AppendLine($"{reciever.Name} is dead!");
			}

			return sb.ToString().Trim();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName  = args[1];

			Character healer = party.FirstOrDefault(x => x.Name == healerName);
			Character healingReceiver = party.FirstOrDefault(x => x.Name == healingReceiverName);

			if (healer == null)
			{
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}
			if (healingReceiver == null)
			{
				throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
			}

			if (healer.GetType().Name != "Priest")
			{
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
			}
			//buh
			healingReceiver.TakeDamage(-healer.AbilityPoints);

			return $"{healer.Name} heals {healingReceiver.Name} for {healer.AbilityPoints}! {healingReceiver.Name} has {healingReceiver.Health} health now!";
		}
	}
}
