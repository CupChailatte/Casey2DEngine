
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using PacmanV2.Components;
using PacmanV2.Entity;
using PacmanV2.Enums;
using Microsoft.Xna.Framework.Graphics;
using PacmanV2.World;

namespace PacmanV2.Systems;


public class InputSystem : IUpdateSystem
{
    private EntityManager _entityManager;
    private KeyboardState _currentKBS, _previousKBS;
    private EntityState _entityState { get; set; } = EntityState.Right;
    private float _rotationAngle = 0f;
    private EntityState _latestFacingDirection { get; set; }

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
            _entityState = EntityState.Up;

        }
        else if (_currentKBS.IsKeyDown(Keys.Down))
        {
            GridDirection = new Vector2(0, 1);
            _entityState = EntityState.Down;
        }
        else if (_currentKBS.IsKeyDown(Keys.Right))
        {
            GridDirection = new Vector2(1, 0);
            _entityState = EntityState.Right;
        }
        else if (_currentKBS.IsKeyDown(Keys.Left))
        {
            GridDirection = new Vector2(-1, 0);
            _entityState = EntityState.Left;

        }

        if (GridDirection != Vector2.Zero)
        {
            _latestFacingDirection = _entityState;
            foreach (var entityID in _entityManager.GetEntityWithComponent<PlayerTag>())
            {
                var sprite = _entityManager.GetComponent<RenderComponent>(entityID);
                var movement = _entityManager.GetComponent<GridMovementComponent>(entityID);
                var transform = _entityManager.GetComponent<TransformComponent>(entityID);

                if (sprite != null)
                {
                    sprite.Effects = SpriteEffects.None;
                }

                if (movement != null)
                {
                    movement.Direction = GridDirection;
                }
                switch (_latestFacingDirection)
                {
                    case EntityState.Right:
                        transform.Rotation = 0f; // 0 grader 
                        break;
                    case EntityState.Down:
                        transform.Rotation = MathHelper.PiOver2; // grader
                        break;
                    case EntityState.Left:
                        transform.Rotation = MathHelper.Pi;// 180 grader 
                        break;
                    case EntityState.Up:
                        transform.Rotation = MathHelper.PiOver2 * 3; // 270 grader 
                        break;
                }
            }

            foreach (var ghost in _entityManager.GetEntityWithComponent<GhostTag>())
            {
                _latestFacingDirection = _entityState;
                var sprite = _entityManager.GetComponent<RenderComponent>(ghost);
                var movement = _entityManager.GetComponent<GridMovementComponent>(ghost);
                var transform = _entityManager.GetComponent<TransformComponent>(ghost);
                if (sprite != null)
                {
                    sprite.Effects = SpriteEffects.None;
                }

                if (movement != null)
                {
                    movement.Direction = GridDirection;
                }
                switch (_latestFacingDirection)
                {
                    case EntityState.Right:
                        transform.Rotation = 0f; // 0 grader 
                        break;
                    case EntityState.Down:
                        transform.Rotation = MathHelper.PiOver2; // grader
                        break;
                    case EntityState.Left:
                        transform.Rotation = MathHelper.Pi;// 180 grader 
                        break;
                    case EntityState.Up:
                        transform.Rotation = MathHelper.PiOver2 * 3; // 270 grader 
                        break;
                }
            }
        }



    }

}