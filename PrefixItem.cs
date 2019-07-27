using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace PrefixesPlus
{
    public class PrefixItem : GlobalItem
    {
        public byte mana;
        public byte critDamage;
        public byte hp;
        public byte regen;

        public PrefixItem()
        {
            mana = 0;
            critDamage = 0;
            hp = 0;
            regen = 0;
        }

        public override bool InstancePerEntity => true;

        public override GlobalItem Clone(Item item, Item itemClone)
        {
            PrefixItem myClone = (PrefixItem) base.Clone(item, itemClone);
            myClone.mana = mana;
            myClone.critDamage = critDamage;
            myClone.hp = hp;
            myClone.regen = regen;
            return myClone;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (!item.social && item.prefix > 0)
            {
                int bonus = mana - Main.cpItem.GetGlobalItem<PrefixItem>().mana;
                if (bonus > 0)
                {
                    TooltipLine line = new TooltipLine(mod, "ManaPrefix", "+" + bonus + " Mana");
                    line.isModifier = true;
                    tooltips.Add(line);
                }
            }

            if (!item.social && item.prefix > 0)
            {
                int bonus = critDamage - Main.cpItem.GetGlobalItem<PrefixItem>().critDamage;
                if (bonus > 0)
                {
                    TooltipLine line = new TooltipLine(mod, "CritDamagePrefix", "+" + bonus + "% Crit Damage");
                    line.isModifier = true;
                    tooltips.Add(line);
                }
            }

            if (!item.social && item.prefix > 0)
            {
                int bonus = hp - Main.cpItem.GetGlobalItem<PrefixItem>().hp;
                if (bonus > 0)
                {
                    TooltipLine line = new TooltipLine(mod, "HpPrefix", "+" + bonus + " Max Life");
                    line.isModifier = true;
                    tooltips.Add(line);
                }
            }

            if (!item.social && item.prefix > 0)
            {
                int bonus = regen - Main.cpItem.GetGlobalItem<PrefixItem>().regen;
                if (bonus > 0)
                {
                    TooltipLine line = new TooltipLine(mod, "RegenPrefix",
                        "+" + Math.Round(bonus / 2.0, 1) + " Life Regen");
                    line.isModifier = true;
                    tooltips.Add(line);
                }
            }
        }

        public override bool NewPreReforge(Item item)
        {
            mana = 0;
            critDamage = 0;
            hp = 0;
            regen = 0;
            return base.NewPreReforge(item);
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (item.GetGlobalItem<PrefixItem>().mana > 0)
            {
                player.statManaMax2 += mana;
            }

            if (item.GetGlobalItem<PrefixItem>().critDamage > 0)
            {
                player.GetModPlayer<PrefixPlayer>().critDamage += critDamage;
            }

            if (item.GetGlobalItem<PrefixItem>().hp > 0)
            {
                player.statLifeMax2 += hp;
            }

            if (item.GetGlobalItem<PrefixItem>().regen > 0)
            {
                player.lifeRegen += regen;
            }

            base.UpdateEquip(item, player);
        }

        public override void NetSend(Item item, BinaryWriter writer)
        {
            writer.Write(mana);
            writer.Write(critDamage);
            writer.Write(hp);
            writer.Write(regen);
        }

        public override void NetReceive(Item item, BinaryReader reader)
        {
            mana = reader.ReadByte();
            critDamage = reader.ReadByte();
            hp = reader.ReadByte();
            regen = reader.ReadByte();
        }
        
    }
}