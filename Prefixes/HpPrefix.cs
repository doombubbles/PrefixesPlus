using Terraria;

namespace PrefixesPlus.Prefixes
{
	public abstract class HpPrefix : PrefixPlus
	{
		protected abstract byte Hp { get; }

		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += Hp;
		}

		public override string GetTooltip() => $"+{Hp} life";

		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1f + Hp * .1f;
		}

		public class Fresh : HpPrefix
		{
			protected override byte Hp => 5;
		}
		
		public class Tough : HpPrefix
		{
			protected override byte Hp => 10;
		}
		
		public class Healthy : HpPrefix
		{
			protected override byte Hp => 15;
		}
		
		public class Vigorous : HpPrefix
		{
			protected override byte Hp => 5;
		}
		
	}
}