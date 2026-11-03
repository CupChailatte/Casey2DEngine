

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacmanV2.World;

public class WorldTile
{
    public Texture2D TileTexture { get; set; }
    public Vector2 TilePosition { get; set; }
    public bool IsWalkable { get; set; }
    public bool IsCollectible { get; set; }
    public const int TileSize = 32;

    public WorldTile(Texture2D tileTexture, Vector2 tilePosition, bool isWalkable = true, bool isCollectible = false)
    {
        TileTexture = tileTexture;
        TilePosition = tilePosition;
        IsWalkable = isWalkable;
        IsCollectible = isCollectible;
    }

    public void Draw(SpriteBatch spriteBatch)
    {

        spriteBatch.Draw(TileTexture, TilePosition, Color.White);
    }

    public static WorldTile Floor(Vector2 tilePos) => new WorldTile(GameAssets.TextureAssets.floor, tilePos, true);
    public static WorldTile Wall(Vector2 tilePos) => new WorldTile(GameAssets.TextureAssets.wall, tilePos, false);
    public static WorldTile Pellets(Vector2 tilePos) => new WorldTile(GameAssets.TextureAssets.wall, tilePos, true, true);

}