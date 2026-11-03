
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using PacmanV2.Components;
using PacmanV2.Entity;

namespace PacmanV2.Systems;


public class InputSystem : IUpdateSystem
{
    private EntityManager _entityManager;
    private KeyboardState _currentKBS, _previousKBS;
    private EntityDirection _entityDirection { get; set; } = EntityDirection.Right;
    private EntityDirection _latestFacingDirection { get; set; }

    public InputSystem(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }

    public void Update(GameTime gameTime)
    {
        _currentKBS = Keyboard.GetState();
        Vector2 GridDirection = Vector2.Zero;
        if (_currentKBS.IsKeyDown(Keys.Up))
        {
            GridDirection = new Vector2(0, -1);
            _entityDirection = EntityDirection.Up;
        }
        else if (_currentKBS.IsKeyDown(Keys.Down))
        {
            GridDirection = new Vector2(0, 1);
            _entityDirection = EntityDirection.Down;
        }
        else if (_currentKBS.IsKeyDown(Keys.Right))
        {
            GridDirection = new Vector2(1, 0);
            _entityDirection = EntityDirection.Right;
        }
        else if (_currentKBS.IsKeyDown(Keys.Left))
        {
            GridDirection = new Vector2(-1, 0);
            _entityDirection = EntityDirection.Left;
        }

        if (GridDirection != Vector2.Zero)
        {
            _latestFacingDirection = _entityDirection;
            foreach (var entityID in _entityManager.GetEntityWithComponent<PlayerTag>())
            {
                var movement = _entityManager.GetComponent<GridMovementComponent>(entityID);
                if (movement != null)
                {
                    movement.Direction = GridDirection;

                }
            }
        }



    }

}