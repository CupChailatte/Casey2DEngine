using Microsoft.Xna.Framework;
using PacmanV2.World;
using PacmanV2.Enums;

namespace PacmanV2.Components;

public class GridMovementComponent : IComponent
{
    public Vector2 PixelDestination { get; set; } = Vector2.Zero;
    public Vector2 Direction { get; set; } = Vector2.Zero;

    public bool IsMoving { get; set; } = false;
    public float Speed;


    public EntityDirection entityDirection;
    public EntityDirection latestDirection { get; set; } = EntityDirection.Right;

    public GridMovementComponent(float speed)
    {
        Speed = speed;
    }
}