
using Engine.ECS;
using Microsoft.Xna.Framework;

namespace Engine.Components;

public class GridMovementComponent : IComponent
{
    public Point CurrentGridPosition { get; set; } = Point.Zero;
    public Point NextGridPosition { get; set; } = Point.Zero;

    public Point CurrentDirection { get; set; } = new Point(1, 0);
    public Point NextDirection { get; set; } = Point.Zero;
    public float Speed { get; set; } = 100f;
    public bool IsMoving { get; set; } = true;
    public GridMovementComponent(float speed, bool isMoving)
    {
        Speed = speed;
        IsMoving = isMoving;
    }
}