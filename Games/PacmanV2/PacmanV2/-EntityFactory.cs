
using System;
using Microsoft.Xna.Framework;
using PacmanV2.Components;
using PacmanV2.Entity;
using PacmanV2.Data;
using PacmanV2.GameAssets;


public class EntityFactory
{
    private EntityManager _entityManager;
    private EntiyRegistry _registry;


    public EntityFactory(EntityManager entityManager, EntiyRegistry _entityRegistry)
    {
        _entityManager = entityManager;
        _registry = _entityRegistry;
    }

    public int SpawnPacman(Point startPos)
    {
        int entityID = _entityManager.CreateEntity();
        var movement = new GridMovementComponent(startPos, 100f);
        var sprite = new SpriteComponent(TextureAssets.pacman);

        var transform = new TransformComponent();

        _entityManager.AddComponent(entityID, movement);
        _entityManager.AddComponent(entityID, sprite);
        _entityManager.AddComponent(entityID, transform);
        Console.WriteLine(entityID);

        return entityID;
    }

}