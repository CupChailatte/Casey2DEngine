
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

    public int CreatePellet(string archetype, Vector2 startPos)
    {
        var data = _registry.Get(archetype);
        int pelletID = _entityManager.CreateEntity();

        var transform = new TransformComponent(startPos);
        _entityManager.AddComponent(pelletID, transform);

        switch (archetype)
        {
            case "pellet":
                var pelletSprite = new RenderComponent(TextureAssets.placeholder)
                {
                    Color = EntityRegistry.ParseColor(data.Color),
                    LayerDepth = 0.3f
                };
                _entityManager.AddComponent(pelletID, pelletSprite);
                break;
        }


        return pelletID;

    }

    public int CreateEntity(string archetype, Vector2 startPos)
    {
        var data = _registry.Get(archetype);
        int entityID = _entityManager.CreateEntity();

        var tranform = new TransformComponent(startPos) { Scale = new Vector2(data.Scale.X, data.Scale.Y) };
        var movement = new GridMovementComponent(data.Speed);


        _entityManager.AddComponent(entityID, tranform);
        _entityManager.AddComponent(entityID, movement);

        switch (archetype)
        {
            case "pacman":
                var playerTag = new PlayerTag();
                var sprite = new RenderComponent(TextureAssets.placeholder2)
                {
                    Color = EntityRegistry.ParseColor(data.Color),
                    LayerDepth = 0.9f
                };
                _entityManager.AddComponent(entityID, playerTag);
                _entityManager.AddComponent(entityID, sprite);
                break;
            case "pinky":
                var pinkySprite = new RenderComponent(TextureAssets.placeholder)
                {
                    Color = EntityRegistry.ParseColor(data.Color),
                    LayerDepth = 0.7f

                };
                _entityManager.AddComponent(entityID, pinkySprite);
                break;
            case "blinky":
                var blinkySprite = new RenderComponent(TextureAssets.placeholder)
                {
                    Color = EntityRegistry.ParseColor(data.Color),
                    LayerDepth = 0.7f
                };
                _entityManager.AddComponent(entityID, blinkySprite);
                break;
            case "clyde":
                var clydeSprite = new RenderComponent(TextureAssets.placeholder)
                {
                    Color = EntityRegistry.ParseColor(data.Color),
                    LayerDepth = 0.7f
                };
                _entityManager.AddComponent(entityID, clydeSprite);
                break;
            case "inky":
                var inkySprite = new RenderComponent(TextureAssets.placeholder)
                {
                    Color = EntityRegistry.ParseColor(data.Color),
                    LayerDepth = 0.7f
                };
                _entityManager.AddComponent(entityID, inkySprite);
                break;
        }
        return entityID;
    }

}