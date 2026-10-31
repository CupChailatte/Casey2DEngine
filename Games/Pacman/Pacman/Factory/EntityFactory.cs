using System;
using Engine.Component;
using Engine.ECS;
using Microsoft.Xna.Framework;

namespace Pacman.Factory;

//? Factory Design Pattern 
//! Uppgift: bara ASSEMBLA COMPONENTS till entities inget annat 

public class EntityFactory
{

    private readonly EntityManager _entities; // Dependency Injection 

    public EntityFactory(EntityManager entities)
    {
        ArgumentNullException.ThrowIfNull(entities);
        _entities = entities;
    }

    public int CreatePacman(Vector2 startPosition)
    {
        int _pacman = _entities.CreateEntity(); // createEntity returnar 1 (id för pacman)
        Console.WriteLine($"Pacman Entity Created, ID: {_pacman}");
        Vector2 scale = Vector2.One;
        float rotation = 0f;

        var transform = new TransformComponent(startPosition, rotation, scale);
        var sprite = new RenderComponent(GameAssets.TextureAsset.pacman)
        {
            Color = Color.Yellow
        };

        _entities.AddComponent(_pacman, transform);
        _entities.AddComponent(_pacman, sprite);

        return _pacman;
    }


    public int CreatePinky(Vector2 startPosition)
    {
        int pinky = _entities.CreateEntity();

        Vector2 scale = new(32, 32);
        float rotation = 0f;

        var transform = new TransformComponent(startPosition, rotation, scale);
        var sprite = new RenderComponent(GameAssets.TextureAsset.pacman)
        {
            Color = Color.Pink
        };

        _entities.AddComponent(pinky, transform);
        _entities.AddComponent(pinky, sprite);

        return pinky;
    }

}