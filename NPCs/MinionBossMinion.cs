using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using TEST.Projectiles;
using TEST.NPCs;


namespace TEST.NPCs
{
    // The minions spawned when the body spawns
    // Please read MinionBossBody.cs first for important comments, they won't be explained here again
    public class MinionBossMinion : ModNPC
    {
        // This is a neat trick that uses the fact that NPCs have all NPC.ai[] values set to 0f on spawn (if not otherwise changed).
        // We set ParentIndex to a number in the body after spawning it. If we set ParentIndex to 3, NPC.ai[0] will be 4. If NPC.ai[0] is 0, ParentIndex will be -1.
        // Now combine both facts, and the conclusion is that if this NPC spawns by other means (not from the body), ParentIndex will be -1, allowing us to distinguish
        // between a proper spawn and an invalid/"cheated" spawn
        public int ParentIndex
        {
            get => (int)NPC.ai[0] - 1;
            set => NPC.ai[0] = value + 1;
        }

        public bool HasParent => ParentIndex > -1;

        public float PositionIndex
        {
            get => NPC.ai[1];
            set => NPC.ai[1] = value;
        }

        public const float RotationTimerMax = 360;
        public ref float RotationTimer => ref NPC.ai[2];

        // Helper method to determine the body type
        public static int BodyType()
        {
            return ModContent.NPCType<Crim>();
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 1;

            // By default enemies gain health and attack if hardmode is reached. this NPC should not be affected by that
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            // Enemies can pick up coins, let's prevent it for this NPC
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            // Automatically group with other bosses
            NPCID.Sets.BossBestiaryPriority.Add(Type);

            // Specify the debuffs it is immune to
            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] {
                    BuffID.Poisoned,

                    BuffID.Confused // Most NPCs have this
				}
            };
            NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);

            // Optional: If you don't want this NPC to show on the bestiary (if there is no reason to show a boss minion separately)
            // Make sure to remove SetBestiary code aswell
            // NPCID.Sets.NPCBestiaryDrawModifiers bestiaryData = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
            //	Hide = true // Hides this NPC from the bestiary
            // };
            // NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, bestiaryData);
        }

        public override void SetDefaults()
        {
            NPC.width = 30;
            NPC.height = 30;
            NPC.damage = 70;
            NPC.defense = 0;
            NPC.lifeMax = 5000;
            NPC.HitSound = SoundID.NPCHit9;
            NPC.DeathSound = SoundID.NPCDeath11;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0.8f;
            NPC.netAlways = true;

            NPC.aiStyle = -1;
        }



        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            cooldownSlot = ImmunityCooldownID.Bosses; // use the boss immunity cooldown counter, to prevent ignoring boss attacks by taking damage from other sources
            return true;
        }



        public override void AI()
        {
            if (Despawn())
            {
                return;
            }


            MoveInFormation();
        }

        private bool Despawn()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient &&
                (!HasParent || !Main.npc[ParentIndex].active || Main.npc[ParentIndex].type != BodyType()))
            {
                // * Not spawned by the boss body (didn't assign a position and parent) or
                // * Parent isn't active or
                // * Parent isn't the body
                // => invalid, kill itself without dropping any items
                NPC.active = false;
                NPC.life = 0;
                NetMessage.SendData(MessageID.SyncNPC, number: NPC.whoAmI);
                return true;
            }
            return false;
        }

        

        private void MoveInFormation()
        {
            NPC parentNPC = Main.npc[ParentIndex];

            // This basically turns the NPCs PositionIndex into a number between 0f and TwoPi to determine where around
            // the main body it is positioned at
            float rad = (float)PositionIndex * MathHelper.TwoPi;


            float distanceFromBody = parentNPC.width + NPC.width;

            // offset is now a vector that will determine the position of the NPC based on its index
            Vector2 offset = Vector2.One.RotatedBy(rad) * distanceFromBody;

            Vector2 destination = parentNPC.Center + offset;
            Vector2 toDestination = destination - NPC.Center;
            Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.Zero);
                  
            float speed = 8-30f;
            float inertia = 20;

            Vector2 moveTo = toDestinationNormalized * speed;
            NPC.velocity = (NPC.velocity * (inertia - 1) + moveTo) / inertia;
        }
    }
}