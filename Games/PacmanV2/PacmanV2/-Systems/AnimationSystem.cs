

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PacmanV2.Animation;
using PacmanV2.Enums;

namespace PacmanV2.Systems;

public class AnimationSystem : ISystem
{
    private readonly Texture _spriteSheet;
    public SpriteEffects Effects { get; set; } = SpriteEffects.None;
    private readonly Dictionary<EntityState, AnimationClip> _animations = [];

    public AnimationClip _currentClip;
    private int _currentFrameIndex;
    private float _timer;

    public bool IsFinnished { get; set; }

    public AnimationSystem(Texture2D spriteSheet)
    {
        _spriteSheet = spriteSheet;
    }

    public void AddAnimation(AnimationClip animationClip)
    {

        _animations[animationClip.State] = animationClip;
        if (animationClip == null)
        {
            Console.WriteLine("Ass");
        }
    }

    public void PlayAnimation(EntityState entityState)
    {
        if (_animations.TryGetValue(entityState, out var clip))
        {
            _currentClip = clip;
            _currentFrameIndex = 0;
            _timer = 0f;
            IsFinnished = false;
        }
    }

    public void Update(GameTime gameTime)
    {

    }

    public void Draw(SpriteBatch spriteBatch) { }

}