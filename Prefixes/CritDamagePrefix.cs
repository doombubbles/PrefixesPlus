using Terraria;

namespace PrefixesPlus.Prefixes
{
	public abstract class CritDamagePrefix : PrefixPlus
	{
		protected abstract byte CritDamage { get; }

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<PrefixPlayer>().critDamage += CritDamage;
		}

		public override string GetTooltip() => $"+{CritDamage}% critical strike damage";

		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1 + CritDamage * .02f;
		}

		public class Opportune : CritDamagePrefix
		{
			protected override byte CritDamage => 5;
		}
	
		public class Decisive : CritDamagePrefix
		{
			protected override byte CritDamage => 10;
		}
		
	}
}