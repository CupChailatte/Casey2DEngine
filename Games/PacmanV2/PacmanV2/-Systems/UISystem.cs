using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

    //* bryter mot single responsibilit
    private Texture2D _textBoxTexture;
    private SpriteFont _textBoxFont;
    private Rectangle _textBox = new Rectangle(0, 0, 900, 1000);
    private string _text = "GAME OVER";
    private Vector2 _textPosition;

    public UISystem(ScoreSystem scoreSystem, HealthSystem healthSystem, EntityManager entityManager)
    {
        _scoreSystem = scoreSystem;
        _healthSystem = healthSystem;
        _entityManager = entityManager;

    }

    public void LoadUIContent(GraphicsDevice graphicsDevice)
    {
        _textBoxFont = TextureAssets.UIFont;
        _textBoxTexture = new Texture2D(graphicsDevice, 1, 1);
        _textBoxTexture.SetData(new[] { Color.White });
        Vector2 textSize = _textBoxFont.MeasureString(_text);
        _textPosition = new Vector2(
            _textBox.X + (_textBox.Width - textSize.X) / 2f,
            _textBox.Y + (_textBox.Height - textSize.Y) / 2f
            );

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        string text1 = "SCORE: " + _scoreSystem.TotalScore;
        string text2 = "HEALTH: " + _healthSystem.GetPlayerHealth();
        spriteBatch.DrawString(TextureAssets.UIFont, text1, _textPos, Color.Yellow);
        spriteBatch.DrawString(TextureAssets.UIFont, text2, _textPos + new Vector2(padding, 0), Color.Yellow);

        if (_healthSystem.GetPlayerHealth() == 0)
        {
            spriteBatch.Draw(_textBoxTexture, _textBox, Color.Red);
            spriteBatch.DrawString(_textBoxFont, _text, _textPosition, Color.Black);
        }
    }
}