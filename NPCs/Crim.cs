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
    public class Crim : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Minion Boss Minion");
            Main.npcFrameCount[Type] = 1;
        }

        public override void SetDefaults()
        {
            NPC.width = 30;
            NPC.height = 30;
            NPC.damage = 7;
            NPC.defense = 0;
            NPC.lifeMax = 5000;
            NPC.HitSound = SoundID.NPCHit9;
            NPC.DeathSound = SoundID.NPCDeath11;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0.8f;
            NPC.netAlways = true;
            NPC.boss = true;
            NPC.aiStyle = 30;
        }



    }
}