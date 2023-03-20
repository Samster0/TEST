using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using TEST.Projectiles;


namespace TEST.NPCs
{
    // The minions spawned when the body spawns
    // Please read MinionBossBody.cs first for important comments, they won't be explained here again
    public class Classy : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Keeper");
            Main.npcFrameCount[Type] = 6;
        }

        public override void SetDefaults()
        {
            NPC.width = 110;
            NPC.height = 110;
            NPC.SpawnWithHigherTime(30);
 
            NPC.damage = 7;
            NPC.defense = 0;
            NPC.lifeMax = 15000;
            NPC.HitSound = SoundID.NPCHit9;
            NPC.DeathSound = SoundID.NPCDeath11;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0.8f;
            NPC.netAlways = true;
            NPC.boss = true;
            NPC.aiStyle = 31;
         
        }

        public override void AI()
        { 

                    if (Main.player[NPC.target].dead)
            

                NPC.active = false;


        }
}
}