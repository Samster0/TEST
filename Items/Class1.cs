using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Test.Items
{
    public class Class1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Example Bow");
            Tooltip.SetDefault("This is an example bow.");
        }

        public override void SetDefaults()
        {
            Item.damage = 1000;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 20;
            Item.useTime = 1;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.noMelee = true;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.InfluxWaver;
            Item.shootSpeed = 50f;
        }

 
    }
}
