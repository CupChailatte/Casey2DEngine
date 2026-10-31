using System;
using Engine.Components;
using Engine.ECS;
using Microsoft.Xna.Framework;
using Pacman.Data;

namespace Pacman.Factory;

//? Factory Design Pattern 
//! Uppgift: bara ASSEMBLA COMPONENTS till entities inget annat 

public class EntityFactory
{

    private readonly EntityManager _entityManager; // Dependency Injection 
    private readonly BlueprintRegistry _blueprintRegistry;

    public EntityFactory(EntityManager entities, BlueprintRegistry registry)
    {
        ArgumentNullException.ThrowIfNull(entities);
        ArgumentNullException.ThrowIfNull(registry);
        _entityManager = entities;
        _blueprintRegistry = registry;

    }


    public int CreatePacman(Vector2 startPosition)
    {
        int pacman = _entityManager.CreateEntity(); // createEntity returnar 1 (id för pacman)
        Console.WriteLine($"Pacman Entity Created, ID: {pacman}");
        Vector2 scale = Vector2.One;
        float rotation = 0f;

        var transform = new TransformComponent(startPosition, rotation, scale);
        var sprite = new RenderComponent(GameAssets.TextureAsset.pacman)
        {
            Color = Color.Yellow
        };

        var movement = new MovementComponent(speed: 200);
        _entityManager.AddComponent(pacman, new PlayerTag());
        _entityManager.AddComponent(pacman, transform);
        _entityManager.AddComponent(pacman, sprite);
        _entityManager.AddComponent(pacman, movement);

        return pacman;
    }


    public int CreatePinky(Vector2 startPosition)
    {
        int pinky = _entityManager.CreateEntity();

        Vector2 scale = new(32, 32);
        float rotation = 0f;

        var transform = new TransformComponent(startPosition, rotation, scale);
        var sprite = new RenderComponent(GameAssets.TextureAsset.pacman)
        {
            Color = Color.Pink
        };

        _entityManager.AddComponent(pinky, transform);
        _entityManager.AddComponent(pinky, sprite);

        return pinky;
    }

    public int SpawnPacman(Vector2 startPos)
    {
        int entityID = CreateBaseEntity("pacman", startPos);
        var playerTag = new PlayerTag();
        _entityManager.AddComponent(entityID, playerTag);

        return entityID;
    }

    public int CreateBaseEntity(string blueprintKey, Vector2 startPos)
    {
        var data = _blueprintRegistry.Get(blueprintKey);
        int entityID = _entityManager.CreateEntity();

        Vector2 scale = new Vector2(data.Scale.X, data.Scale.Y);
        var tranform = new TransformComponent(startPos, rotation: 0f, scale);
        var sprite = new RenderComponent(GameAssets.TextureAsset.pacman) { Color = BlueprintRegistry.ParseColor(data.Color) };

        _entityManager.AddComponent(entityID, tranform);
        _entityManager.AddComponent(entityID, sprite);
        if (data.Speed > 0f)
        {
            _entityManager.AddComponent(entityID, new MovementComponent(speed: data.Speed));
        }

        return entityID;
    }


}