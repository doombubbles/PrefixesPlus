using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace PrefixesPlus
{
    public class PrefixItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            // var prev = Main.tooltipPrefixComparisonItem.TryGetGlobalItem<PrefixItem>(out var prefixItem);
            if (!item.social && PrefixLoader.GetPrefix(item.prefix) is PrefixPlus prefix)
            {
                tooltips.Add(new TooltipLine(Mod, prefix.Name, prefix.GetTooltip())
                {
                    IsModifier = true
                });
            }
        }
        
        public override void UpdateEquip(Item item, Player player)
        {
            if (PrefixLoader.GetPrefix(item.prefix) is PrefixPlus prefix)
            {
                prefix.UpdateEquip(player);
            }
        }
        
    }
}