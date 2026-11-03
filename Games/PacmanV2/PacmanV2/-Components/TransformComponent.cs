
using Microsoft.Xna.Framework;

namespace PacmanV2.Components;

public class TransformComponent : IComponent
{
    public Vector2 PixelPosition { get; set; }
    public Vector2 Scale { get; set; }
    public float Rotation { get; set; } = 0f;

    //Default constructor : om jag kallar på denna constructorn tilldelas default värden
    public TransformComponent() : this(Vector2.Zero, 0f, Vector2.One) { }

    //constructor för bara position
    public TransformComponent(Vector2 startPos) : this(startPos, 0f, Vector2.One) { }

    // master constructor 
    public TransformComponent(Vector2 startPos, float rotation, Vector2 scale)
    {
        PixelPosition = startPos;
        Rotation = rotation;
        Scale = scale;
    }
}