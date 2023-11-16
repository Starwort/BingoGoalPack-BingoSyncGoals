﻿using BingoBoardCore.AnimationHelpers;
using BingoGoalPackBingoSyncGoals.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    internal class NPCIcon : ModItem {
        private class AnyTownNPC : AssetCycleAnimation {
            private static Random rng = new();

            public override Asset<Texture2D> getFrame(uint frame) {
                var idx = Sets.TownNPCs[rng.Next(Sets.TownNPCs.Count)];
                return TextureAssets.Npc[idx];
            }
        }
        public override string Texture => $"Terraria/Images/NPC_{npcId}";
        int npcId;
        int npcFrameTime;

        public override string Name => $"NPCIcon/{npcId}";

        public static Item AnyTown = null!;

        public static Item Angler = null!;
        public static Item Clothier = null!;
        public static Item Dog = null!;
        public static Item Golfer = null!;
        public static Item Stylist = null!;
        public static Item BlazingWheel = null!;
        public static Item DungeonGuardian = null!;

        public NPCIcon() {
            this.npcId = NPCID.None;
            AnyTown = ModContent.GetInstance<AnyTownNPC>().Item;
        }

        public NPCIcon(int npcId, int npcFrameTime = 6) {
            this.npcId = npcId;
            this.npcFrameTime = npcFrameTime;
        }

        public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(npcFrameTime, Main.npcFrameCount[npcId]));
        }

        public override bool IsLoadingEnabled(Mod mod) => npcId != NPCID.None;

        public static void registerItems() {
            Item add(int id, int frameTime = 6) {
                NPCIcon icon = new(id, frameTime);
                ModContent.GetInstance<BingoGoalPackBingoSyncGoals>().AddContent(
                    icon
                );
                return icon.Item;
            }
            Angler = add(NPCID.Angler);
            Clothier = add(NPCID.Clothier);
            Dog = add(NPCID.TownDog);
            Golfer = add(NPCID.Golfer);
            Stylist = add(NPCID.Stylist);
            BlazingWheel = add(NPCID.BlazingWheel, 3);
            DungeonGuardian = add(NPCID.DungeonGuardian);
        }
    }
}