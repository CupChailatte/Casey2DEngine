using Engine.ECS;
using Engine.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman.World;

public class WorldTile : IRenderSystem
{
    public Texture2D TileTexture { get; set; }
    public Vector2 TilePosition { get; set; }
    public bool IsWalkable { get; set; }
    public bool IsCollectible { get; set; }
    public const int TileSize = 32; // add to json? 

    public WorldTile(Texture2D texture, Vector2 position, bool isWalkable = true, bool isCollectible = false)
    {
        TileTexture = texture;
        TilePosition = position;
        IsWalkable = isWalkable;
        IsCollectible = isCollectible;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(TileTexture, TilePosition, Color.White);
    }

    public static WorldTile Floor(Vector2 pos) => new WorldTile(GameAssets.TextureAsset.floorTile, pos);
    public static WorldTile Wall(Vector2 pos) => new WorldTile(GameAssets.TextureAsset.wallTile, pos);



}