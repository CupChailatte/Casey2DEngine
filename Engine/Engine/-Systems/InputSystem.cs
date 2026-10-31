
using System;
using Engine.Components;
using Engine.ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine.Systems;

public class InputSystem : ISystem
{
    private readonly EntityManager _entityManager;

    public InputSystem(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }

    public void Update()
    {
        var keyboard = Keyboard.GetState();
        Vector2 direction = Vector2.Zero;

        if (keyboard.IsKeyDown(Keys.Up) || keyboard.IsKeyDown(Keys.W))
        {
            direction = new Vector2(0, -1);
        }
        else if (keyboard.IsKeyDown(Keys.Down) || keyboard.IsKeyDown(Keys.S))
            direction = new Vector2(0, 1);
        else if (keyboard.IsKeyDown(Keys.Left) || keyboard.IsKeyDown(Keys.A))
            direction = new Vector2(-1, 0);
        else if (keyboard.IsKeyDown(Keys.Right) || keyboard.IsKeyDown(Keys.D))
            direction = new Vector2(1, 0);

        if (direction == Vector2.Zero) return;

        // hämtar bara entity med PlayerTag (playern ska bara kunna röra sig med tangent. )
        foreach (var entityID in _entityManager.GetEntityWithComponent<PlayerTag>())
        {
            // hämtar playerns movement comp
            var movement = _entityManager.GetComponent<MovementComponent>(entityID);
            if (movement != null)
            {
                movement.NextDirection = direction;
            }
        }
    }
}