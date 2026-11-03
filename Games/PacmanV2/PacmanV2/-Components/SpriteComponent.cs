using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacmanV2.Components;

public class RenderComponent : IComponent
{
    public Texture2D SpriteTexture { get; set; }
    public Rectangle? SourceRectangle { get; set; } // för animation 

    public Color Color { get; set; }
    public SpriteEffects Effects { get; set; }

    public Vector2 Origin { get; set; } = Vector2.Zero;
    public float LayerDepth { get; set; } = 0f;

    // constructor för statiska entity/tiles 
    public RenderComponent(Texture2D texture) : this(texture, null) { }

    public RenderComponent(Texture2D spriteTexture, Rectangle? sourceRectangle)
    {
        // "Rectangle(?)" gör den nullable. Eftersom Rectangle är en struct kan det normalt inte vara null
        // Om den är null, rita upp hela texturen. SourceRectangle är för att rita en specifik områden på en textur. 
        ArgumentNullException.ThrowIfNull(spriteTexture);
        SpriteTexture = spriteTexture;
        SourceRectangle = sourceRectangle;
    }
}