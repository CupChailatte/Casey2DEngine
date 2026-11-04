
using System;
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
    public CollisionSystem(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }

    public static event EventHandler<PelletsEatenEventArgs> OnPelletEaten;

    public void Update(GameTime gameTime)
    {
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
                WorldLoader.tileType[playerGridPos.Y, playerGridPos.X] = TileType.Empty;
                // Observer pattern
                OnPelletEaten?.Invoke(this, new PelletsEatenEventArgs(playerGridPos));
            }
        }

    }

}