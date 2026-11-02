
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Engine.ECS;
using Engine.Enums; 
using Engine.Components;
using System;

namespace Pacman.Systems;

public class PacmanInputSystem : IUpdateSystem
{
    private KeyboardState _currentKBS, _previousKBS;
    private EntityManager _entityManager; 
    private EntityDirection _latestFacingDirection {get;set; }
    private EntityDirection _entityDirection {get;set;}
    public PacmanInputSystem(EntityManager entityManager)
    {
        _entityManager = entityManager; 
        
    }
    public void Update(GameTime gameTime)
    {
        _currentKBS = Keyboard.GetState();
        Point Direction = Point.Zero;
        if (_currentKBS.IsKeyDown(Keys.Left))
        {
            Direction.X--;
            _entityDirection = EntityDirection.Left;
            Console.WriteLine(_entityDirection); 
        }
        else if (_currentKBS.IsKeyDown(Keys.Right))
        {
            Direction.X++;
            _entityDirection = EntityDirection.Right; 
        }
        else if (_currentKBS.IsKeyDown(Keys.Up))
        {
            Direction.Y--;
            _entityDirection = EntityDirection.Up; 
        }
        else if (_currentKBS.IsKeyDown(Keys.Down))
        {
            Direction.Y++; 
            _entityDirection = EntityDirection.Down; 
        } 

        if (Direction != Point.Zero)
        {
            _latestFacingDirection = _entityDirection; 
            Console.WriteLine(_entityDirection); 
        } 

        foreach (var entityID in _entityManager.GetEntityWithComponent<PlayerTag>())
        {
            var movement = _entityManager.GetComponent<GridMovementComponent>(entityID); 
            if (movement != null)
            {
                movement.Direction += Direction; 
            }
        }

    }


    public void IsKeyPressed()
    {
        _currentKBS = _previousKBS; 
        _previousKBS = Keyboard.GetState(); 
        
    }

}
