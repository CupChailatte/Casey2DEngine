
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Pacman.GameAssets;

public static class TextureAsset
{
    public static Texture2D pacman { get; set; }
    public static Texture2D floorTile { get; set; }
    public static Texture2D wallTile { get; set; }

    public static SpriteFont DebugText { get; set; }

    public static void LoadTextureAssets(ContentManager content)
    {
        Console.WriteLine("GameAssets: Textures Loaded");
        pacman = content.Load<Texture2D>("pacman_spriteSmoll2");
        floorTile = content.Load<Texture2D>("floortile");
        wallTile = content.Load<Texture2D>("walltile");


        DebugText = content.Load<SpriteFont>("DebugFont");
    }
}