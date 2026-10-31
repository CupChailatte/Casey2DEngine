using Engine.ECS;
using Microsoft.Xna.Framework;

namespace Engine.Components;

public class TransformComponent : IComponent
{
    public Vector2 Position { get; set; }
    public float Rotation { get; set; } = 0f;
    public Vector2 Scale { get; set; }

    //* Här använder jag "Constructor Chaining" 

    // standart contructor : om jag inte skickar in något värde i parametern, tilldelas default värden  
    public TransformComponent() : this(Vector2.Zero, 0f, Vector2.One) { }

    // constructor för bara position
    public TransformComponent(Vector2 position) : this(position, 0f, Vector2.One) { }

    // "Master" constructor - tilldelar värden som vanlig 
    public TransformComponent(Vector2 position, float rotation, Vector2 scale)
    {
        Position = position;
        Rotation = rotation;
        Scale = scale;
    }

}