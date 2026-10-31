using Engine.Components;
using Engine.ECS;
using Microsoft.Xna.Framework;

namespace Engine.Systems;


public class MovementSystem : ISystem
{
    private readonly EntityManager _entityManager;

    public MovementSystem(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }

    public void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        foreach (var entityID in _entityManager.GetEntityWithComponent<MovementComponent>())
        {
            var transform = _entityManager.GetComponent<TransformComponent>(entityID);
            var movement = _entityManager.GetComponent<MovementComponent>(entityID);

            // kollar om entity har transform eller movement component. 
            if (transform == null || movement == null) continue;
            // Om jag ska lägga tile based movement, måste jag kolla om nästa position eller grid 
            // är ledig eller gångbar. 
            if (movement.NextDirection != Vector2.Zero)
            {
                movement.Direction = movement.NextDirection;
            }
            transform.Position += movement.Direction * movement.Speed * deltaTime;



        }
    }
}