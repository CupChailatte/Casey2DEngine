using System;
using Engine.ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Components;
// ska bara ha data för rendering av sprites 
public class RenderComponent : IComponent
{
    public Texture2D Texture { get; set; }
    public Rectangle? SourceRectangle { get; set; } // för animation 

    public Color Color { get; set; } = Color.White;
    public SpriteEffects Effects { get; set; } = SpriteEffects.None;

    public Vector2 Origin { get; set; } = Vector2.Zero; // t.ex mitt punkter för rotation
    public float LayerDepth { get; set; } = 0f; // ordning på renderingen


    //* Här använder jag Constructor Overloading : När en class har flera konstruktor men med olika parameterlistor 

    // för att bara rendera texturen t.ex statiska object 
    public RenderComponent(Texture2D texture) : this(texture, null) { }

    // använder detta för animation
    public RenderComponent(Texture2D texture, Rectangle? sourceRectangle)
    {    // "Rectangle(?)" gör den nullable. Eftersom Rectangle är en struct kan det normalt inte vara null
         // Om den är null, rita upp hela texturen. SourceRectangle är för att rita en specifik områden på en textur. 
        ArgumentNullException.ThrowIfNull(texture);
        Texture = texture;
        SourceRectangle = sourceRectangle;
    }

}