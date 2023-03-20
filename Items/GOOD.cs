using IL.Terraria.GameContent.Biomes.CaveHouse;
using IL.Terraria.Graphics;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TEST.Projectiles;

namespace TEST.Items
{
    public class GOOD : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("HI"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("A noble and ancient weapon, wielded by the strongest of Sangheili");
            DisplayName.SetDefault("Duelist Energy Sword");

        }

        public override void SetDefaults()
        {
            Item.damage = 80;
            Item.DamageType = DamageClass.Melee;
            Item.width = 17;
            Item.height = 19;
            Item.useTime = 15;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 10;
            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.crit = 15;
            Item.shoot = ProjectileID.MagnetSphereBall;
            Item.shootSpeed = 25f;
            
        }

        public override void AddRecipes()
        {
            Recipe recipemodded = CreateRecipe();
            recipemodded.AddIngredient(ModContent.ItemType<BYE>());
            recipemodded.AddIngredient(ItemID.MagnetSphere, 1);
            recipemodded.AddTile(TileID.AdamantiteForge);
            recipemodded.Register();

        }

        public override bool CanUseItem(Player player)
        {
            // Check if the player is not shooting the first projectile
            if (Item.shoot == ProjectileID.MagnetSphereBall)
            {
                Item.shoot = ProjectileID.IceSickle; // Set the second projectile type
            }
            else
            {
                Item.shoot = ProjectileID.MagnetSphereBall; // Set the first projectile type
            }
           
                return base.CanUseItem(player);
        }
        

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {



            if (Main.rand.NextBool(3))
            {
                target.AddBuff(BuffID.Frostburn2, 500);
               
             


            }
        }



        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Electric, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 1f;
        }


        
    }



}
