using Terraria;
using Terraria.ModLoader;

namespace PrefixesPlus.Prefixes
{
    public abstract class RegenPrefix : PrefixPlus
    {
        protected abstract byte Regen { get; }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult = 1f + .1f * Regen;
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += Regen;
        }

        public override string GetTooltip() => $"+{Regen} life regen";


        public class RefreshingPrefix : RegenPrefix
        {
            protected override byte Regen => 1;

            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("Refreshing");
            }
        }
    }
}