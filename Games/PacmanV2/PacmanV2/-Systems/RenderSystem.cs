using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PacmanV2.Components;
using PacmanV2.Entity;
using PacmanV2.Systems;

public class RenderSystem : IRenderSystem
{
    private EntityManager _entityManager;

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

            // null check av componenterna
            if (render == null || transform == null) continue;

            // rita? 
            spriteBatch.Draw(
                texture: render.SpriteTexture,
                position: transform.PixelPosition,
                color: render.Color,
                sourceRectangle: render.SourceRectangle,
                effects: render.Effects,
                rotation: transform.Rotation,
                origin: render.Origin,
                scale: transform.Scale,
                layerDepth: render.LayerDepth);
        }

    }
}