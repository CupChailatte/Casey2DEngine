using Microsoft.Xna.Framework;

namespace PacmanV2.Components;

public class GridMovementComponent : IComponent
{
    // hastighet entityn rör sig per pixel 
    public float Speed { get; set; } = 100f;

    // grid position i hel tal
    // NextGridPosition - ska använda det för att kolla om nästa tile är gångbar 
    public Point CurrentGridPosition { get; set; }
    public Point NextGridPosition { get; set; }

    // Riktningar 
    public Point CurrentDirection { get; set; } = Point.Zero;
    public Point NextDirection { get; set; } = Point.Zero;

    // låter GridMovementSystem veta om entityn har gått till nästa til när de glider 
    public bool IsMoving { get; set; } = false;
    public GridMovementComponent(Point startGridPos, float speed)
    {
        CurrentGridPosition = startGridPos;
        NextGridPosition = startGridPos;
        Speed = speed;
        IsMoving = false;
    }

}