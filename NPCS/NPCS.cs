using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;

namespace TEST.NPCs
{
    public class NPCS : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TRU");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];
        }

        public override void SetDefaults()
        {
            NPC.width = 32;
            NPC.height = 15;
            NPC.damage = 99;
            NPC.defense = 300;
            NPC.lifeMax = 2000;
            NPC.value = 50f;
            NPC.aiStyle = 51;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.boss = true;
            NPC.noGravity = true;
          

            

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * 100f;
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter >= 20) 
            {
                NPC.frameCounter = 0;
            }
            NPC.frame.Y = (int)NPC.frameCounter / 10 * frameHeight;
        }

        public override void OnKill()
        {
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.VortexBeater, Main.rand.Next(0, 2));
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.TempleKey, Main.rand.Next(5, 10));
        }

        public override void AI()
        {
            if (NPC.life > NPC.lifeMax / 2)
            {
                // boss attacks when its health is above 50%
               
                if (NPC.frameCounter % 60 == 0)
                {
                    // boss does an attack every second
                    Player target = Main.player[NPC.target];
                    Vector2 direction = target.Center - NPC.Center;
                    direction.Normalize();
                    int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 10f, ProjectileID.FlamingScythe, NPC.damage, 0f);
                  
                }
            }
            else
            {
                // boss attacks more aggressively when its health is below 50%
                if (NPC.frameCounter % 30 == 0)
                {
                    // boss does an attack every half second
                    Player target = Main.player[NPC.target];
                    Vector2 direction = target.Center - NPC.Center;
                    direction.Normalize();
                    int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 10f, ProjectileID.FrostWave, NPC.damage, 0f);
                }
            }
        }






    }
}