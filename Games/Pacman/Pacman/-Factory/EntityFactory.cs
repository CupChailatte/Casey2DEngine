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

    public int SpawnPacman(Vector2 startPos)
    {
        int entityID = CreateBaseEntity("pacman", startPos);
        var playerTag = new PlayerTag();
        _entityManager.AddComponent(entityID, playerTag);
        Console.WriteLine($"Spawned Pacman, ID: {entityID}");
        return entityID;
    }

    public int SpawnTestPacman(Vector2 startPos)
    {
        var data = _blueprintRegistry.Get("pacman2");
        int entityId = CreateBaseEntity("pacman2", startPos);

        var playerTag = new PlayerTag();
        _entityManager.AddComponent(entityId, playerTag);
        Console.WriteLine($"Spawned Pacman, ID: {entityId}");

        var entityColor = _entityManager.GetComponent<RenderComponent>(entityId);
        entityColor.Color = BlueprintRegistry.ParseColor(data.Color);
        return entityId;
    }


    public int SpawnPinky(Vector2 startPosition)
    {
        int pinkyID = CreateBaseEntity("pinky", startPosition);

        return pinkyID;

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