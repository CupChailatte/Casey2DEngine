

using Microsoft.Xna.Framework;

namespace PacmanV2.Components;

public class CollisionComponent : IComponent
{

    public int HitboxWidth;
    public int HitBoxHeight;

    public CollisionComponent(int hitboxWidth, int hitboxHeight)
    {
        HitboxWidth = hitboxWidth;
        HitBoxHeight = hitboxHeight;
    }

    public Rectangle GetHitboxBounds(Vector2 entityPosition)
    {
        return new Rectangle(
            (int)entityPosition.X,
             (int)entityPosition.Y,
              HitboxWidth,
               HitboxWidth
        );
    }

}