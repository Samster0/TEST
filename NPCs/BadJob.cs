using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;
using TEST.Projectiles;


namespace TEST.NPCs
{
    public class BadJob : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elemental Keeper");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];
        }

        public override void SetDefaults()
        {
            NPC.width = 32;
            NPC.height = 15;
            NPC.damage = 99;
            NPC.defense = 30;
            NPC.lifeMax = 2000;
            NPC.value = 50f;
            NPC.aiStyle = -1;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.boss = true;
            NPC.noGravity = true;
            Music = MusicID.Plantera;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0f;



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
            Player player = Main.player[NPC.target];
            NPC.TargetClosest(true);
            if (NPC.Distance(player.Center) > 100)
            {
                NPC.velocity = Vector2.Normalize(player.Center - NPC.Center) * 6f;
            }
            if (NPC.life > NPC.lifeMax / 2)
            {
                // boss attacks when its health is above 50%

                if (NPC.frameCounter % 60 == 0)
                {
                    // boss does an attack every second
                    Player target = Main.player[NPC.target];
                    Vector2 direction = target.Center - NPC.Center;
                    direction.Normalize();
                    int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 10f, ModContent.ProjectileType<Funnything>(), NPC.damage, 50f);


                }
            }
            if(NPC.life < NPC.lifeMax / 2)
            {
                if (NPC.ai[0] == 0f)
                {
                    var entitySource = NPC.GetSource_FromAI();
                    int index = NPC.NewNPC(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<NPCs.Classy>(), NPC.whoAmI);
                    NPC minionNPC = Main.npc[index];




                   
                }

            }
            if (NPC.life < NPC.lifeMax / 2)
            {
                if (NPC.ai[0] == 0f)
                {
                    var entitySource = NPC.GetSource_FromAI();
                    int index = NPC.NewNPC(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<NPCs.Hallow>(), NPC.whoAmI);
                    NPC minionNPC = Main.npc[index];




                    
                }

            }
            if (NPC.life < NPC.lifeMax / 2)
            {
                if (NPC.ai[0] == 0f)
                {
                    var entitySource = NPC.GetSource_FromAI();
                    int index = NPC.NewNPC(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<NPCs.Crim>(), NPC.whoAmI);
                    NPC minionNPC = Main.npc[index];

                    NPC.life = 0;
                    NPC.checkDead();


                    NPC.ai[0] = 1f;
                }

            }





        }
    }
}
