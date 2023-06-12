using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;
using TEST.Projectiles;
using Terraria.Graphics.Capture;
using System;
using Terraria.Audio;
using Terraria.Utilities;
using System.Security.Cryptography.X509Certificates;
using TEST.Items;
using System.Net.Security;
using IL.Terraria.DataStructures;

namespace TEST.NPCs
{
    
    public class BadJob : ModNPC
    {
        public int up = 1;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elemental Keeper");
            Main.npcFrameCount[Type] = 6;

        }

        public override void SetDefaults()
        {
            NPC.width = 110;
            NPC.height = 110;
            NPC.SpawnWithHigherTime(30);
            NPC.damage = 120;
            NPC.defense = 30;
            NPC.lifeMax = 60000;
            NPC.value = 50f;
            NPC.aiStyle = 31;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.boss = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0f;
            NPC.stepSpeed = 100f;
            Music = MusicID.OldOnesArmy;
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
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.GreaterHealingPotion, Main.rand.Next(10, 15));
        }

        public override void AI()
        {
            if (NPC.active == true)
            {
      
                 up = 2;

            }
            Player player = Main.player[NPC.target];
            NPC.TargetClosest(true);
            if (NPC.Distance(player.Center) > 100)
            {
                NPC.velocity = Vector2.Normalize(player.Center - NPC.Center) * 8f;
            }

            if (NPC.frameCounter % 250 == 0)
            {
                // boss does an attack every second
                Player target = Main.player[NPC.target];
                Vector2 direction = target.Center - NPC.Center;
                direction.Normalize();
                int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 10f, ProjectileID.EyeFire, NPC.damage, 50f);


            }
            if (NPC.frameCounter % 250 == 0)
            {
                // boss does an attack every second
                Player target = Main.player[NPC.target];
                Vector2 direction = target.Center - NPC.Center;
                direction.Normalize();
                int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 10f, ProjectileID.EyeLaser, NPC.damage, 50f);


            }

            if (NPC.life < NPC.lifeMax / 2)
            {
                {
                    Main.NewText("The spirits of light and dark have escaped, to kill you!");
                }
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


            if (Main.player[NPC.target].dead)
            {

                NPC.active = false;


            }

        }
    }
}
