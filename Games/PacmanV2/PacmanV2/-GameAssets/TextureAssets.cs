using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace PacmanV2.GameAssets;

public static class TextureAssets
{
    public static Texture2D pacman { get; set; }
    public static Texture2D wall { get; set; }
    public static Texture2D floor { get; set; }

    public static void LoadTextures(ContentManager content)
    {
        Console.WriteLine("Textures Loaded");
        pacman = content.Load<Texture2D>("pacman_spriteSmoll2");
        wall = content.Load<Texture2D>("walltile");
        floor = content.Load<Texture2D>("floortile");

    }
}