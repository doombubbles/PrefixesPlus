using Terraria;
using Terraria.ModLoader;

namespace PrefixesPlus
{
    public abstract class PrefixPlus : ModPrefix
    {
        public override PrefixCategory Category => PrefixCategory.Accessory;

        public abstract void UpdateEquip(Player player);

        public abstract string GetTooltip();
    }
}