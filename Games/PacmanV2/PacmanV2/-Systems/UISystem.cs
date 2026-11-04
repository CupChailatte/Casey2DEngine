using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PacmanV2.GameAssets;
using PacmanV2.Systems;


public class UISystem : IRenderSystem
{
    private ScoreSystem _scoreSystem;
    private Vector2 _textPos { get; set; } = new Vector2(10, 1040);

    public UISystem(ScoreSystem scoreSystem)
    {
        _scoreSystem = scoreSystem;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        string text = "SCORE: " + _scoreSystem.TotalScore;
        spriteBatch.DrawString(TextureAssets.UIFont, text, _textPos, Color.Yellow);
    }
}