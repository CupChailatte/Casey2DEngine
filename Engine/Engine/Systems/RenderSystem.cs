using Engine.ECS;
using Engine.Component;
using Microsoft.Xna.Framework.Graphics;

public class RenderSystem : IRenderSystem
{
    private readonly EntityContainer _entityCollection;

    public RenderSystem(EntityContainer entities)
    {
        _entityCollection = entities;
    }
    public void Initialize() { }
    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (int entityID in _entityCollection.GetEntityWithComponent<RenderComponent>())
        {
            var renderComponent = _entityCollection.GetComponent<RenderComponent>(entityID);
            var tranformComponent = _entityCollection.GetComponent<TransformComponent>(entityID);

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