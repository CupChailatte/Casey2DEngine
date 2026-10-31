using Engine.ECS;
using Microsoft.Xna.Framework;

namespace Engine.Components;


public class MovementComponent : IComponent
{
    public Vector2 Direction { get; set; } = Vector2.Zero;
    public Vector2 NextDirection { get; set; } = Vector2.Zero;
    public float Speed { get; set; } = 100f;

    public MovementComponent(float speed)
    {
        Speed = speed;
    }

}