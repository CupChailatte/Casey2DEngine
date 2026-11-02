using Engine.Components;
using Engine.Systems;
using Engine.ECS;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Linq;

namespace Pacman.Systems;

public class DebugTextSystem : ISystem
{
    private EntityManager _entityManager;
    private SpriteFont _font;
    private Vector2 _textPos;

    public DebugTextSystem(EntityManager entityManager, Vector2 textPos)
    {
        _entityManager = entityManager;
        _textPos = textPos;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _font = GameAssets.TextureAsset.DebugText;
        // hämtar entity med player tag
        var playerEntitiesID = _entityManager.GetEntityWithComponent<PlayerTag>();
        // hämtar id:n
        var playerID = playerEntitiesID.FirstOrDefault();

        var transformComponent = _entityManager.GetComponent<TransformComponent>(playerID);
        string text = $"Current Entity: {playerID} \n" +
                      $"PixelPosition : {transformComponent.Position}\n";

        if (_font != null)
        {
            spriteBatch.DrawString(_font, text, _textPos, Color.Yellow);
        }
    }

}