using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacmanV2.GameState;

public class MenuItem
{
    private string ButtonText { get; set; }
    public Vector2 Position { get; set; }
    public Rectangle Bounds { get; set; }
    public bool IsSelected { get; set; }

    public MenuItem(SpriteFont font, Vector2 position)
    {
        Position = position;
        Vector2 textSize = font.MeasureString(ButtonText);
        Bounds = new Rectangle(
            (int)position.X,
            (int)position.Y,
            (int)textSize.X,
            (int)textSize.Y);

    }

}