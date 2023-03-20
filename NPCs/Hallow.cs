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
    public class Hallow : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bringer of Blight");
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
            NPC.knockBackResist = 0f;
            NPC.netAlways = true;
            NPC.boss= true;

            NPC.aiStyle = 31;
        }

        private bool dashing = false;
        private int dashTimer = 0;
        private const int MAX_DASH_TIME = 60; // the maximum time the boss will dash
        private const int DASH_COOLDOWN_TIME = 180;

        public override void AI()
        {



            if (Main.player[NPC.target].dead)
            {


                NPC.active = false;
            }

        
            if (dashing)
            {
                // Dash towards the player
                Player target = Main.player[NPC.target];
                Vector2 direction = target.Center - NPC.Center;
                direction.Normalize();
                NPC.velocity = direction * 15f;

                dashTimer++;
                if (dashTimer >= MAX_DASH_TIME)
                {
                    dashing = false;
                    dashTimer = 0;
                    NPC.velocity = Vector2.Zero;
                    direction.Normalize();

                }
                
            }
            else
            {
                // Check if the cooldown time has elapsed
                if (NPC.ai[0] == 0f)
                {
                    // Start dashing towards the player
                    dashing = true;
                    NPC.ai[0] = DASH_COOLDOWN_TIME;
                }
                else
                {
                    // Count down the cooldown timer
                    NPC.ai[0]--;
                    
                    if (NPC.frameCounter % 250 == 0)
                    {
                        Player target = Main.player[NPC.target];
                        Vector2 direction = target.Center - NPC.Center;
                        direction.Normalize();
                        int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 10f, ProjectileID.EyeLaser, NPC.damage, 100f);
                    }
                }
            }
        }




    }
}