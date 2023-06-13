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
        private int shotCount;
        private int cooldownTimer = 0;
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
            Item.shoot = 89;
            Item.shootSpeed= 10;
            
        }




    

        public override bool AltFunctionUse(Player player)
        {


            return cooldownTimer <= 0;
        }

        public override void HoldItem(Player player)
        {

            if (cooldownTimer > 0)
            {
                cooldownTimer--;
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
           
            Projectile.NewProjectile(source, position, velocity, ProjectileID.CrystalShard, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(source, position, velocity, ProjectileID.CrystalStorm, damage, knockback, player.whoAmI);
           
            Projectile.NewProjectile(source, position, velocity, ProjectileID.CrystalVileShardHead, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(source, position, velocity, ProjectileID.HolyArrow, damage, knockback, player.whoAmI);




            shotCount++; // Increment the shot count

            if (player.altFunctionUse == 2) // Check if the shot count is divisible by 5
            {
                
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity, ProjectileID.HallowStar, damage, knockback, player.whoAmI);
                player.AddBuff(BuffID.Burning, 60 * 5);
                player.AddBuff(BuffID.PotionSickness, 60 * 5); 
                player.AddBuff(BuffID.ChaosState, 60 * 5);
                player.AddBuff(197, 60 * 5); 
                player.AddBuff(196, 60 * 5);
                player.AddBuff(31, 60 * 5);
                player.AddBuff(20, 60 * 5);
                player.AddBuff(153, 60 * 5);
                cooldownTimer = 300;

            }
            else
            {
                Item.useTime = 15;
            }
            
            return true;
         

        }



 

    }
    
}