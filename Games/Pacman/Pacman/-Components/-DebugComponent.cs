using Engine.ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


public class DebugComponent : IComponent
{
    public SpriteFont font;
    public Vector2 position;

    public DebugComponent(SpriteFont spriteFont, Vector2 textPosition)
    {
        font = spriteFont;
        position = textPosition;
    }

}