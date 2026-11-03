

using Microsoft.Xna.Framework;
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

    public void Draw(GameTime gameTime)
    {
        foreach (var entityID in _entityManager.GetEntityWithComponent<SpriteComponent>())
        {
            var sprite = _entityManager.GetComponent<SpriteComponent>(entityID);

        }

    }
}