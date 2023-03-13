using IL.Terraria.GameContent.Biomes.CaveHouse;
using IL.Terraria.Graphics;
using Microsoft.CodeAnalysis;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TEST.Items
{
	public class HI : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("HI"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Also known as a plasma sword");
			DisplayName.SetDefault("Energy Sword");
		}

		public override void SetDefaults()
		{
			Item.damage = 35;
            Item.DamageType = DamageClass.Melee;
			Item.width = 17;
			Item.height = 19;
			Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 10;
            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
			Item.crit = 5;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StylistKilLaKillScissorsIWish, 1);
			recipe.AddIngredient(ItemID.BluePhaseblade, 1);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.Register();

		}


                    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.NextBool(3))
            {
				target.AddBuff(BuffID.Frostburn, 200);
            }
        }
	}

}