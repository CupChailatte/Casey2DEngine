
using System;
using Microsoft.Xna.Framework;
using PacmanV2.Components;
using PacmanV2.Entity;
using PacmanV2.Data;
using PacmanV2.GameAssets;
using PacmanV2.World;


public class EntityFactory
{
    private EntityManager _entityManager;
    private EntityRegistry _registry;
    private WorldLoader _worldLoader;


    public EntityFactory(EntityManager entityManager, EntityRegistry _entityRegistry, WorldLoader worldLoader)
    {
        _entityManager = entityManager;
        _registry = _entityRegistry;
        _worldLoader = worldLoader;
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

        var movement = new GridMovementComponent(WorldLoader.PixelToGrid(startPos), 20);
        var tranform = new TransformComponent(startPos) { Scale = new Vector2(data.Scale.X, data.Scale.Y) };
        _entityManager.AddComponent(entityID, tranform);
        _entityManager.AddComponent(entityID, movement);

        switch (archetype)
        {
            case "pacman":
                var playerTag = new PlayerTag();
                var sprite = new RenderComponent(TextureAssets.pacman) { Color = EntityRegistry.ParseColor(data.Color) };
                _entityManager.AddComponent(entityID, playerTag);
                _entityManager.AddComponent(entityID, sprite);
                break;
        }




        return entityID;


    }

}