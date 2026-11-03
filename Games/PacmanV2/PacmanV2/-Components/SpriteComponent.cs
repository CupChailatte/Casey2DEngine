using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacmanV2.Components;

public class SpriteComponent : IComponent
{
    public Texture2D SpriteTexture { get; set; }

    public SpriteComponent(Texture2D spriteTexture)
    {
        SpriteTexture = spriteTexture;
    }
}