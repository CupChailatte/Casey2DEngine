using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PacmanV2.Components;
using PacmanV2.Entity;
using PacmanV2.GameAssets;
using PacmanV2.Systems;


public class UISystem : IRenderSystem
{
    private ScoreSystem _scoreSystem;
    private HealthSystem _healthSystem;
    private EntityManager _entityManager;
    private int padding = 200; 
    private int Health; 
    private Vector2 _textPos { get; set; } = new Vector2(10, 1040);

    public UISystem(ScoreSystem scoreSystem, HealthSystem healthSystem, EntityManager entityManager)
    {
        _scoreSystem = scoreSystem;
        _healthSystem = healthSystem; 
        _entityManager = entityManager; 

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        string text1 = "SCORE: " + _scoreSystem.TotalScore;
        string text2 = "HEALTH: " + _healthSystem.GetPlayerHealth(); 
        spriteBatch.DrawString(TextureAssets.UIFont, text1, _textPos, Color.Yellow);
        spriteBatch.DrawString(TextureAssets.UIFont, text2, _textPos + new Vector2(padding,0), Color.Yellow);
    }
}