using System.Net.Security;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TEST.NPCs;
using Terraria.Audio;

namespace TEST.Items
{
    public class spawny : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The elemental coccoon");
            Tooltip.SetDefault("Crush this husk to release the ancient sprits");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 20;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item44;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                // If the player using the item is the client
                // (explicitely excluded serverside here)
                SoundEngine.PlaySound(SoundID.Roar, player.position);

                int type = ModContent.NPCType<BadJob>();

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    // If the player is not in multiplayer, spawn directly
                    NPC.SpawnOnPlayer(player.whoAmI, type);
                }
                else
                {
                    NPC.SpawnOnPlayer(player.whoAmI, type);
                }
            }

            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipemodded = CreateRecipe();
            recipemodded.AddIngredient(ItemID.CrimtaneOre, 50);
            recipemodded.AddIngredient(ItemID.DemoniteOre, 50);
            recipemodded.AddIngredient(ItemID.CrystalShard, 50);
            recipemodded.AddIngredient(ItemID.BeetleHusk, 5);
            recipemodded.AddTile(TileID.DemonAltar);
            recipemodded.Register();

        }
    }

}