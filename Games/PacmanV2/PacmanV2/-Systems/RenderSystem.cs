using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PacmanV2.Components;
using PacmanV2.Entity;
using PacmanV2.Systems;
using PacmanV2.World;

public class RenderSystem : IRenderSystem
{
    private EntityManager _entityManager;
    private bool IsEntity;

    public RenderSystem(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }

    public void Initialize() { }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var entityID in _entityManager.GetEntityWithComponent<RenderComponent>())
        {
            // hämta componenterna, 
            var render = _entityManager.GetComponent<RenderComponent>(entityID);
            var transform = _entityManager.GetComponent<TransformComponent>(entityID);

            if (render == null || transform == null) continue;

            IsEntity =
            _entityManager.HasComponent<RenderComponent>(entityID) ||
            _entityManager.HasComponent<TransformComponent>(entityID);

            Vector2 renderCenterPosition = new Vector2(
                transform.PixelPosition.X + (WorldTile.TileSize / 2f),
                transform.PixelPosition.Y + (WorldTile.TileSize / 2f));

            Vector2 DrawPosition = new Vector2(MathF.Round(renderCenterPosition.X), MathF.Round(renderCenterPosition.Y)); 

            // Håller pacmans sprite origin fäst vid dens interna pixel center 
            Vector2 renderOrigin = render.Origin; 
            if (renderOrigin == Vector2.Zero)
            {
               float frameWidth = render.SourceRectangle.HasValue ? render.SourceRectangle.Value.Width : render.SpriteTexture.Width;
                float frameHeight = render.SourceRectangle.HasValue ? render.SourceRectangle.Value.Height : render.SpriteTexture.Height;
                renderOrigin = new Vector2(frameWidth / 2f, frameHeight / 2f); 
            }

            // null check av componenterna
            if (render == null || transform == null) continue;

            // rita? 
            spriteBatch.Draw(
                texture: render.SpriteTexture,
                position: DrawPosition, // visuel center position 
                color: render.Color,
                sourceRectangle: render.SourceRectangle,
                effects: render.Effects,
                rotation: transform.Rotation,
                origin: renderOrigin, // visuel center rotation/pivot 
                scale: transform.Scale,
                layerDepth: render.LayerDepth);
        }

    }
}