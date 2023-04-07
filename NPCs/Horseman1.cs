using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using TEST.Items;
using TEST.Projectiles;


namespace TEST.NPCs
{
    // The minions spawned when the body spawns
    // Please read MinionBossBody.cs first for important comments, they won't be explained here again
    public class Horseman1 : ModNPC
    {
        private int shootTimer = 0;
        private int shootTime = 0;
        private int talky = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Horseman");
            Main.npcFrameCount[Type] = 4;
        }

        public override void SetDefaults()
        {
            NPC.width = 120;
            NPC.height = 83;

            NPC.damage = 7;
            NPC.defense = 20;
            NPC.lifeMax = 15000;
            NPC.noGravity = false;
            NPC.noTileCollide = false;
            NPC.knockBackResist = 0;
            NPC.netAlways = true;
            NPC.boss = true;
            NPC.aiStyle = 26;
            NPC.dontTakeDamage = true; // set to true until boss is ready to fight
            NPC.alpha = 255; // make boss invisible until midnight
        }

        public override void AI()
        {
            if (NPC.active == true)
            {
                Main.NewText("The Horsemen are drawing nearer On leather steeds they ride They've come to take your life");
            }



            if (Main.dayTime == false && Main.time == 0) // spawn boss at midnight
            {
                NPC.dontTakeDamage = false; // allow boss to take damage
                NPC.alpha = 0; // make boss visible
            }

            if (!Main.dedServ)
            {
                Music = MusicLoader.GetMusicSlot(Mod, "Items/Boo");
            }
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest();
            }

            // Check if player is within 200 pixels
            Player player = Main.player[NPC.target];
            if (Vector2.Distance(player.Center, NPC.Center) < 450f)
            {

                Vector2 dir = player.Center - NPC.Center; // Direction towards player
                dir.Normalize();
                int damage = NPC.damage / 2; // Deal half damage per swing
                int type = ModContent.ProjectileType<TheBlades>();
                Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, dir * 8f, type, damage, 0f);
                {
                    shootTime++;
                    if (shootTime >= 45) // 60 ticks = 1 second
                    {
                        Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, dir * 8f, ProjectileID.DemonSickle, damage, 50f);
                        shootTime = 0;
                    }
                }


            }
            else
            {
                Vector2 dir = player.Center - NPC.Center; // Direction towards player
                dir.Normalize();
                int damage = NPC.damage / 2; // Deal half damage per swing
                NPC.velocity = NPC.DirectionTo(player.Center) * 8f;
                {
                    shootTimer++;
                    if (shootTimer >= 15) // 60 ticks = 1 second
                    {
                        Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, dir * 8f, ProjectileID.DemonSickle, damage, 50f);
                        shootTimer = 0;
                    }
                }

            }
            if (Main.player[NPC.target].dead)
            {


                NPC.active = false;

            }
        }
        public override void FindFrame(int frameHeight)
        {
            // This NPC animates with a simple "go from start frame to final frame, and loop back to start frame" rule
            // In this case: First stage: 0-1-2-0-1-2, Second stage: 3-4-5-3-4-5, 5 being "total frame count - 1"
            int startFrame = 0;
            int finalFrame = 1;
            Player player = Main.player[NPC.target];
            if (Vector2.Distance(player.Center, NPC.Center) < 450f)
            {
                startFrame = 2;
                finalFrame = Main.npcFrameCount[NPC.type] - 1;
                {

                }
                if (NPC.frame.Y < startFrame * frameHeight)
                {
                    // If we were animating the first stage frames and then switch to second stage, immediately change to the start frame of the second stage
                    NPC.frame.Y = startFrame * frameHeight;
                }
            }
            else
            {


            }
            int frameSpeed = 5;
            NPC.frameCounter += 0.5f;
            NPC.frameCounter += NPC.velocity.Length() / 10f; // Make the counter go faster with more movement speed
            if (NPC.frameCounter > frameSpeed)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight;

                if (NPC.frame.Y > finalFrame * frameHeight)
                {
                    NPC.frame.Y = startFrame * frameHeight;
                }
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {



            if (spawnInfo.Player.ZoneGraveyard)
            {




                return 50;
            }





            return 0;






        }


    }
}