
using System;
using Microsoft.Xna.Framework;
using PacmanV2.Components;
using PacmanV2.Entity;
using PacmanV2.Data;
using PacmanV2.GameAssets;


public class EntityFactory
{
    private EntityManager _entityManager;
    private EntityRegistry _registry;


    public EntityFactory(EntityManager entityManager, EntityRegistry _entityRegistry)
    {
        _entityManager = entityManager;
        _registry = _entityRegistry;
    }

    public int SpawnPacman(Point startPos)
    {
        int entityID = _entityManager.CreateEntity();
        var movement = new GridMovementComponent(startPos, 100f);
        var sprite = new RenderComponent(TextureAssets.pacman);
        var transform = new TransformComponent()
        {

        };
        _entityManager.AddComponent(entityID, movement);
        _entityManager.AddComponent(entityID, sprite);
        _entityManager.AddComponent(entityID, transform);
        Console.WriteLine(entityID);

        return entityID;
    }

    public int CreateEntity(string archetype, Vector2 startPos)
    {
        var data = _registry.Get(archetype);
        int entityID = _entityManager.CreateEntity();

        var tranform = new TransformComponent(startPos)
        {
            Scale = new Vector2(data.Scale.X, data.Scale.Y)
        };
        _entityManager.AddComponent(entityID, tranform);

        switch (archetype)
        {
            case "pacman":
                var sprite = new RenderComponent(TextureAssets.pacman)
                {
                    Color = EntityRegistry.ParseColor(data.Color)
                };
                _entityManager.AddComponent(entityID, sprite);
                break;
        }




        return entityID;


    }

}