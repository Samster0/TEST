using IL.Terraria.GameContent.Biomes.CaveHouse;
using IL.Terraria.Graphics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TEST.Items
{
    public class CC : ModItem
    {
        private int frameCount = 4; // Number of frames in the sprite sheet
        private int frameTimer = 0; // Timer for frame switching
        private int currentFrame = 0; // Current frame index

        private bool hipee = true;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("HI"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

            DisplayName.SetDefault("Crystal Cannon");
            Main.itemFrameCounter[frameCount] = 12;
        }

        public override void SetDefaults()
        {
            Item.damage = 65;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 17;
            Item.height = 19;
            Item.useTime = 15;
            Item.useAnimation = 20;
            Item.useStyle = 5;
            Item.knockBack = 10;
            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.crit = 5;
            Item.noMelee= true;
            Item.shoot = ProjectileID.CrystalBullet;
            Item.shootSpeed= 10;
        }
 





        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {


            if (player.altFunctionUse == 2)
            {



                Item.useTime = 1;
                Item.shoot = ProjectileID.HallowStar;

            }
            else
            {
                Item.useTime = 15;
                Item.shoot = 89;

            }


            return true;
        }

        
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, ProjectileID.CrystalDart, damage, knockback);
            float lipee = MathHelper.ToRadians(Main.rand.NextFloat(360f));
 

            Vector2 perturbedSpeed = new Vector2(8, 8).RotatedBy(lipee);

            velocity += perturbedSpeed;
            if (player.altFunctionUse == 2)
            {
                
                
                    Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                    Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                    Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                    Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                

                return false;
            }
          
            
            return true;
         

        }

    }
}