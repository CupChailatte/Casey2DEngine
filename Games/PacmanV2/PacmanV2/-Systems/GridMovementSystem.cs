
using Microsoft.Xna.Framework;
using PacmanV2.Components;
using PacmanV2.Entity;
using PacmanV2.World;
using SharpDX.Direct2D1.Effects;

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

        // går igenom entities som har gridmovecomp 
        foreach (var entityID in _entityManager.GetEntityWithComponent<GridMovementComponent>())
        {
            // hämtar comp som tillhör entity IDn. 
            var transform = _entityManager.GetComponent<TransformComponent>(entityID);
            var movement = _entityManager.GetComponent<GridMovementComponent>(entityID);

            //applicerar logik för GRID MOVEMENT : 
            if (transform == null || movement == null) continue;

            if (!movement.IsMoving)
            {
                if (movement.NextDirection != Point.Zero)
                {
                    // psudo kod: nästa position = nuposition + 1 riktning  
                    // calculerar vart nästa tile är 
                    Point TargetGridPos = movement.CurrentGridPosition + movement.NextDirection;

                    if (WorldLoader.IsTileWalkable(TargetGridPos.X, TargetGridPos.Y))
                    {
                        movement.NextGridPosition = TargetGridPos;
                        movement.CurrentDirection = movement.NextDirection;
                        movement.IsMoving = true;
                    }
                }
            }

            if (!movement.IsMoving) continue;

            // applicerar logik för PIXEL POSITION´

            // pixel destinationen 
            Vector2 TargetPixelPosition = new Vector2(
                movement.NextGridPosition.X * WorldTile.TileSize,
                movement.NextGridPosition.Y * WorldTile.TileSize);

            float stepDistance = movement.Speed * deltaTime;
            // calculerar distansen mellan punkA och punkB
            float distanceToTarget = Vector2.Distance(transform.PixelPosition, TargetPixelPosition);

            if (distanceToTarget <= stepDistance)
            {
                transform.PixelPosition = TargetPixelPosition;

                movement.CurrentGridPosition = movement.NextGridPosition;
                movement.IsMoving = false;
            }
            else
            {
                Vector2 slideVector = new Vector2(movement.CurrentDirection.X, movement.CurrentDirection.Y);
                transform.PixelPosition += slideVector * stepDistance;
            }

        }
    }
}