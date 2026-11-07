using Microsoft.Xna.Framework;
using System.Collections.Generic;

using PacmanV2.Enums;
using Microsoft.Xna.Framework.Graphics;

namespace PacmanV2.Animation;

public class AnimationClip
{
    public EntityState State;
    public List<Rectangle> Frames = [];
    public float TimePerFrame { get; set; }
    public bool IsLooping { get; set; }
    public SpriteEffects Effects { get; set; }

    public AnimationClip(EntityState entityState, float timerPerFrame, bool isLooping = true, SpriteEffects effects = SpriteEffects.None)
    {
        State = entityState;
        TimePerFrame = timerPerFrame;
        IsLooping = isLooping;
        Effects = effects;

    }

    public void AddSourceRectangle(Rectangle sourceRectangle)
    {
        Frames.Add(sourceRectangle);
    }

    public void AddFrames(int startRow, int startColumn, int totalFrames, int frameWidth, int frameHeight)
    {
        for (int i = 0; i < totalFrames; i++)
        {
            int col = startColumn * i;
            int startX = col * frameWidth;
            int startY = startRow * frameHeight;

            AddSourceRectangle(new Rectangle(startX, startY, frameWidth, frameHeight));
            //                     Rectangle(startPositionX, startPositionY, frameWidth, frameHeight)

        }

    }

}
