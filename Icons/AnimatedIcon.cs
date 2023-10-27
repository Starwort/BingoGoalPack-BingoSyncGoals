﻿using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace BingoGoalPackBingoSyncGoals.Icons {
    public abstract class AnimatedIcon : ModItem {
        // Placeholder, used to give tML something to load
        public override string Texture => $"Terraria/Images/CoolDown";

        // Get the textureasset corresponding with what to show this frame
        // only called when the texture should update, so safe to make stateful decisions
        // (like calling an rng)
        internal abstract Asset<Texture2D> getFrame(uint frame);

        // Set the next frame of the animation. The frame parameter corresponds
        // to the total number of frames displayed so far. Will only be called
        // when we want a new frame
        internal void animate(uint frame) {
            TextureAssets.Item[Type] = getFrame(frame);
        }
    }
}