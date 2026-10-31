using Engine.ECS;
using Engine.Components;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Systems;

public class RenderSystem : IRenderSystem
{
    private readonly EntityManager _entityManager;

    public RenderSystem(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }
    public void Initialize() { }
    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (int entityID in _entityManager.GetEntityWithComponent<RenderComponent>())
        {
            var renderComponent = _entityManager.GetComponent<RenderComponent>(entityID);
            var tranformComponent = _entityManager.GetComponent<TransformComponent>(entityID);

            // entity som har render och tranform kommer att ritas ut, annars inte.         
            if (renderComponent.Texture != null && tranformComponent != null)

            {
                spriteBatch.Draw(
                    texture: renderComponent.Texture,
                    position: tranformComponent.Position,
                    sourceRectangle: renderComponent.SourceRectangle,
                    color: renderComponent.Color,
                    rotation: tranformComponent.Rotation,
                    origin: renderComponent.Origin,
                    scale: tranformComponent.Scale,
                    effects: renderComponent.Effects,
                    layerDepth: renderComponent.LayerDepth
                );
            }
        }
    }


}