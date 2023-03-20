
using Microsoft.Xna.Framework;
using System;
using System.Net.Security;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ModLoader;
using TEST.NPCs;


namespace TEST.Biome
{
    // Shows setting up two basic biomes. For a more complicated example, please request.
    public class HIS : ModBiome
    {
        // Select all the scenery

        // Select Music
        public override int Music => Terraria.ID.MusicID.TownNight;


        // Use SetStaticDefaults to assign the display name
        public override void SetStaticDefaults()
        {

             DisplayName.SetDefault("Example Surface");
        }

        // Calculate when the biome is active.
        public override bool IsBiomeActive(Player player)
        {


            NPC npc = Main.npc[1];
            if (npc.active && npc.life > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            

        }
    }
}