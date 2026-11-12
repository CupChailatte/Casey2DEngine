
using System;
using Microsoft.Xna.Framework;
using PacmanV2.Components;
using PacmanV2.Entity;
using PacmanV2.Data;
using PacmanV2.GameAssets;
using PacmanV2.World;
using PacmanV2.Animation;


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

    public int CreateEntity(string archetype, Vector2 startPos)
    {
        var data = _registry.Get(archetype);
        int entityID = _entityManager.CreateEntity();

        var tranform = new TransformComponent(startPos) { Scale = new Vector2(data.Scale.X, data.Scale.Y) };
        var movement = new GridMovementComponent(data.Speed);
        var hp = new HPComponent(maxHp: data.maxHP);
        var hitbox = new CollisionComponent(32, 32);

        _entityManager.AddComponent(entityID, hitbox);
        _entityManager.AddComponent(entityID, tranform);
        _entityManager.AddComponent(entityID, movement);
        _entityManager.AddComponent(entityID, hp);


        switch (archetype)
        {
            case "pacman":
                var playerTag = new PlayerTag();
                var sprite = new RenderComponent(TextureAssets.spriteSheet)
                {
                    Color = EntityRegistry.ParseColor(data.Color),
                    LayerDepth = 0.9f
                };

                var eatingAnimation = new AnimationClip(new Rectangle[]
                {
                    new Rectangle(0,0,16,16),
                    new Rectangle(16,0,16,16),
                    new Rectangle(32,0,16,16),
                }, frameDuration: 0.1f);
                var animation = new AnimationComponent(eatingAnimation);


                _entityManager.AddComponent(entityID, playerTag);
                _entityManager.AddComponent(entityID, sprite);
                _entityManager.AddComponent(entityID, animation);
                sprite.SourceRectangle = eatingAnimation.Frames[0];

                break;
            case "pinky":
                var pinkySprite = new RenderComponent(TextureAssets.spriteSheet)
                {
                    Color = EntityRegistry.ParseColor(data.Color),
                    LayerDepth = 0.7f

                };
                var tag = new GhostTag(); 
                var pinkyAnimation = new AnimationClip(new Rectangle[]
                {
                    new Rectangle(0,32,16,16),
                    new Rectangle(16,32,16,16),
                });
                var pinkyAnima = new AnimationComponent(pinkyAnimation);
                _entityManager.AddComponent(entityID, tag); 
                _entityManager.AddComponent(entityID, pinkySprite);
                _entityManager.AddComponent(entityID, pinkyAnima);
                pinkySprite.SourceRectangle = pinkyAnimation.Frames[0]; 

                break;
            case "blinky":
                var blinkySprite = new RenderComponent(TextureAssets.spriteSheet)
                {
                    Color = EntityRegistry.ParseColor(data.Color),
                    LayerDepth = 0.7f
                }; 
                var blinkyAnimation = new AnimationClip(new Rectangle[]
                {
                    new Rectangle(0,16,16,16),
                    new Rectangle(16,16,16,16),
                });
                var blinkyAnim = new AnimationComponent(blinkyAnimation); 
                var hitboxA = new CollisionComponent(32, 32);

                _entityManager.AddComponent(entityID, hitboxA);
                _entityManager.AddComponent(entityID, blinkySprite);
                _entityManager.AddComponent(entityID, blinkyAnim); 
                blinkySprite.SourceRectangle = blinkyAnimation.Frames[0]; 
                break;
            case "clyde":
                var clydeSprite = new RenderComponent(TextureAssets.spriteSheet)
                {
                    Color = EntityRegistry.ParseColor(data.Color),
                    LayerDepth = 0.7f
                };
                var clydeClip = new AnimationClip(new Rectangle[]
                {
                    new Rectangle(0, 48, 16,16 ), 
                    new Rectangle(16, 48, 16,16 ), 
                }); 
                var clydeAnim = new AnimationComponent(clydeClip); 
                _entityManager.AddComponent(entityID, clydeSprite);
                _entityManager.AddComponent(entityID, clydeAnim); 
                clydeSprite.SourceRectangle = clydeClip.Frames[0]; 
                break;
            case "inky":

                var inkySprite = new RenderComponent(TextureAssets.spriteSheet)
                {
                    Color = EntityRegistry.ParseColor(data.Color),
                    LayerDepth = 0.7f
                };
                var inkyClip = new AnimationClip(new Rectangle[]
                {
                    new Rectangle(0, 64, 16,16), 
                    new Rectangle(16, 64, 16,16), 
                }); 

                var inkyAnim = new AnimationComponent(inkyClip); 
                _entityManager.AddComponent(entityID, inkySprite);
                _entityManager.AddComponent(entityID, inkyAnim); 
                inkySprite.SourceRectangle = inkyClip.Frames[0]; 
                break;
        }
        return entityID;
    }

}