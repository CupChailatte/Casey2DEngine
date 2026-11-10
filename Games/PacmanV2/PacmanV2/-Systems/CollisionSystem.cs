using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using PacmanV2.Components;
using PacmanV2.Entity;
using PacmanV2.Enums;
using PacmanV2.Events;
using PacmanV2.World;

namespace PacmanV2.Systems;
//? Kollar collision mellan entities och mellan entities och tiles  
//* Applicerar logik när collisom händer 
//Jag kan kolla collision genom Rectangle eller position check 
// för static objekts så kollar jag om pacmans pos == objekt pos 

public class CollisionSystem : IUpdateSystem
{
    private EntityManager _entityManager;
    private WorldLoader _worldLoader;
    // återanvändbar buffer 
    // ? Buffer = är "pre-allocated" chunks av minne som kan återanvändas om och om igen. Måste använda Clear(); 
    private readonly List<int> _entityBuffer = new List<int>();

    public CollisionSystem(EntityManager entityManager, WorldLoader worldLoader)
    {
        _entityManager = entityManager;
        _worldLoader = worldLoader;
    }

    public static event EventHandler<OnPelletsEatenEventArgs> OnPelletEaten;
    public static event EventHandler<OnEntityCollisionEventArgs> OnEntityCollision; 
    // public static event EventHandler<OnCollisionEventArgs> OnCollision;

    // --- COLLISION BETWEEN ENTITIES BY COLLISION CHECKS --- 

    public void Update(GameTime gameTime)
    {
        // tar bort förra frames entitiy IDs, kopierar de nya utan att skapa/allokera nya objekt 
        _entityBuffer.Clear();
        _entityBuffer.AddRange(_entityManager.GetEntityWithComponent<CollisionComponent>());

        var entities = _entityManager.GetEntityWithComponent<CollisionComponent>();
        var count = entities.Count();
        // get entity 1 
        for (int i = 0; i < count; i++)
        {
            int entityA = _entityBuffer[i];
            var collisionA = _entityManager.GetComponent<CollisionComponent>(entityA);
            var transformA = _entityManager.GetComponent<TransformComponent>(entityA);

            if (collisionA == null || transformA == null) continue;
            // get entity 2 
            for (int j = i + 1; j < count; j++)
            {
                int entityB = _entityBuffer[j];
                var collisionB = _entityManager.GetComponent<CollisionComponent>(entityB);
                var transformB = _entityManager.GetComponent<TransformComponent>(entityB);
                if (collisionB == null || transformB == null) continue;

                Rectangle HitboxA = collisionA.GetHitboxBounds(transformA.PixelPosition);
                Rectangle HitboxB = collisionB.GetHitboxBounds(transformB.PixelPosition);

                if (HitboxA.Intersects(HitboxB))
                {
                   OnEntityCollision?.Invoke(this, new OnEntityCollisionEventArgs()); 
                }
            }
        }

        // --- TILE COLLISION BY POSITION CHECKS --- 
        foreach (var entityID in _entityManager.GetEntityWithComponent<PlayerTag>())
        {
            var transform = _entityManager.GetComponent<TransformComponent>(entityID);

            // omvandlar playerPixelPos till gridPos 
            Point playerGridPos = new Point(
            (int)transform.PixelPosition.X / WorldTile.TileSize,
            (int)transform.PixelPosition.Y / WorldTile.TileSize);

            TileType currentTilePos = WorldLoader.tileType[playerGridPos.Y, playerGridPos.X];

            // tar bort pellets om pos  == pelletpos 
            if (currentTilePos == TileType.Pellet)
            {
                // tar bort sprite 
                WorldLoader.tileType[playerGridPos.Y, playerGridPos.X] = TileType.Empty;

                // tar bort pellet mängd
                _worldLoader.DecreasePelletAmount();

                // Observer pattern
                OnPelletEaten?.Invoke(this, new OnPelletsEatenEventArgs(playerGridPos));


            }
        }

    }

}

