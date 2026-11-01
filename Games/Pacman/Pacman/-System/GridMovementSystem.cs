using Engine.ECS;
using Engine.Components;
using System;
using Microsoft.Xna.Framework;

namespace Pacman.Systems;

public class GridMovementSystem : IUpdateSystem
{
    private readonly EntityManager _entityManager;

    public void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        var EntityPosition = _entityManager.GetComponent<TransformComponent>(1);
        Console.Write(EntityPosition.Position);

        foreach (var entityID in _entityManager.GetEntityWithComponent<GridMovementComponent>())
        {
            var gridMovement = _entityManager.GetComponent<GridMovementComponent>(entityID);
            var transform = _entityManager.GetComponent<TransformComponent>(entityID);

            if (gridMovement == null || transform == null) continue;

            if (gridMovement.NextDirection != Point.Zero)
            {
                gridMovement.CurrentDirection = gridMovement.NextDirection;
            }
        }
    }
}



/*
1. Get the same entityManager that is used 
2. loop trhorugh the collection 
3. Get the components to use 
4. Implement  


*/