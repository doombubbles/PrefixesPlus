using Terraria;

namespace PrefixesPlus.Prefixes
{
	public abstract class ManaPrefix : PrefixPlus
	{
		protected abstract byte Mana { get; }

		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1 + Mana / 200f;
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += Mana;
		}

		public override string GetTooltip() => $"+{Mana} mana";

		public class Mysterious : ManaPrefix
		{
			protected override byte Mana => 10;
		}
		
		public class Mystical : ManaPrefix
		{
			protected override byte Mana => 30;
		}
		
		public class Sorcerous : ManaPrefix
		{
			protected override byte Mana => 40;
		}
	}
}