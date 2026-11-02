using Engine.ECS;
using Engine.Systems;
using Engine.Components;
using Microsoft.Xna.Framework;

namespace Pacman.Systems; 


public class PacmanMovementSystem : IUpdateSystem
{
    private EntityManager _entityManager; 
    public PacmanMovementSystem(EntityManager entityManager)
    {
        _entityManager = entityManager; 
    }
    public void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds; 

        foreach(var entityID in _entityManager.GetEntityWithComponent<PlayerTag>())
        {
            var gridMovement = _entityManager.GetComponent<GridMovementComponent>(entityID);
            var transform = _entityManager.GetComponent<TransformComponent>(entityID); 

            if (gridMovement == null || transform == null) continue; 

            
        }

    }
}