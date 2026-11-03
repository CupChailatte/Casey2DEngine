
using Microsoft.Xna.Framework;
using PacmanV2.Components;
using PacmanV2.Entity;
using PacmanV2.World;

namespace PacmanV2.Systems;

public class GridMovementSystem : IUpdateSystem
{
    private EntityManager _entityManager;
    public GridMovementSystem(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }

    public void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        foreach (var entity in _entityManager.GetEntityWithComponent<GridMovementComponent>())
        {
            var transform = _entityManager.GetComponent<TransformComponent>(entity);
            var movement = _entityManager.GetComponent<GridMovementComponent>(entity);

            if (transform == null || movement == null) continue;

            if (!movement.IsMoving && movement.Direction != Vector2.Zero)
            {
                if (movement.Direction != Vector2.Zero)
                {
                    // hämtar entity currentPos 
                    Point currentGridPos = WorldLoader.PixelToGrid(transform.PixelPosition);
                    // räknar ut nästa pos 
                    Point targetGridPos = new Point(
                    currentGridPos.X + (int)movement.Direction.X,
                    currentGridPos.Y + (int)movement.Direction.Y);
                    // kollar om nästa pos är gång bar 
                    if (WorldLoader.IsTileWalkable(targetGridPos.X, targetGridPos.Y))
                    {
                        movement.PixelDestination = transform.PixelPosition + (movement.Direction * WorldTile.TileSize);
                        movement.IsMoving = true;
                    }
                }
            }

            if (movement.IsMoving)
            {
                Vector2 directionToTarget = movement.PixelDestination - transform.PixelPosition;
                float distanceToTarget = directionToTarget.Length();

                float moveAmount = movement.Speed * deltaTime;

                if (moveAmount > distanceToTarget)
                {
                    transform.PixelPosition = movement.PixelDestination;
                    movement.IsMoving = false;
                }
                else
                {
                    directionToTarget.Normalize();
                    transform.PixelPosition += directionToTarget * moveAmount;
                }
            }


        }

    }
}
