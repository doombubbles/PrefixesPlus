using Terraria;
using Terraria.ModLoader;

namespace PrefixesPlus
{
    public class PrefixPlayer : ModPlayer
    {
        public float critDamage;

        public override void ResetEffects()
        {
            critDamage = 0f;
        }
        
        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (crit)
            {
                damage += (int)(damage * (player.GetModPlayer<PrefixPlayer>().critDamage / 200f));
            }
            base.ModifyHitNPC(item, target, ref damage, ref knockback, ref crit);
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit,
            ref int hitDirection)
        {
            if (crit)
            {
                damage += (int)(damage * (player.GetModPlayer<PrefixPlayer>().critDamage / 200f));
            }
            base.ModifyHitNPCWithProj(proj, target, ref damage, ref knockback, ref crit, ref hitDirection);
        }
        
        public override void ModifyHitPvpWithProj(Projectile proj, Player target, ref int damage, ref bool crit)
        {
            if (crit)
            {
                damage += (int)(damage * (player.GetModPlayer<PrefixPlayer>().critDamage / 200f));
            }
            base.ModifyHitPvpWithProj(proj, target, ref damage, ref crit);
        }
        
        public override void ModifyHitPvp(Item item, Player target, ref int damage, ref bool crit)
        {
            if (crit)
            {
                damage += (int)(damage * (player.GetModPlayer<PrefixPlayer>().critDamage / 200f));
            }
            base.ModifyHitPvp(item, target, ref damage, ref crit);
        }
    }
}