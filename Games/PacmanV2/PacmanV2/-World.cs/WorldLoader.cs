using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PacmanV2.Entity;
using PacmanV2.Enums;

namespace PacmanV2.World;

public class WorldLoader
{
    public static WorldTile[,] tileArray;
    public static TileType[,] tileType;
    private EntityManager _entityManager;
    private EntityFactory _entityFactory;
    public WorldLoader(EntityManager entityManager, EntityFactory entityFactory)
    {
        _entityManager = entityManager;
        _entityFactory = entityFactory;
    }

    // TODO flytta till egen klass senare   
    public List<string> ReadMapFile(string filePath)
    {
        using StreamReader reader = new StreamReader(filePath);
        List<string> readerResult = [];
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            readerResult.Add(line);
            Console.WriteLine(line);
        }
        return readerResult;
    }

    public void LoadWorld(string filePath)
    {
        List<string> lines = ReadMapFile(filePath);

        int worldWidth = lines[0].Length; // X
        int worldHeight = lines.Count; // Y

        tileArray = new WorldTile[worldHeight, worldWidth];
        tileType = new TileType[worldHeight, worldWidth];

        for (int y = 0; y < worldHeight; y++)
        {
            for (int x = 0; x < worldWidth; x++)
            {
                char tileChar = lines[y][x]; // position av char 

                Vector2 PixelPosition = new Vector2(x * WorldTile.TileSize, y * WorldTile.TileSize);
                // Point GridPosition = new Point((int)PixelPosition.X / WorldTile.TileSize, (int)PixelPosition.Y / WorldTile.TileSize);
                WorldTile Floor = WorldTile.Floor(PixelPosition);
                switch (tileChar)
                {
                    case '#':
                        tileArray[y, x] = WorldTile.Wall(PixelPosition);
                        tileType[y, x] = TileType.Wall;
                        break;
                    case '.':
                        tileArray[y, x] = Floor;
                        tileType[y, x] = TileType.Pellet;
                        break;
                    case 'p':
                        tileArray[y, x] = Floor;
                        tileType[y, x] = TileType.Empty;
                        int pinky = _entityFactory.CreateEntity("pinky", PixelPosition);
                        break;
                    case 'b':
                        tileArray[y, x] = Floor;
                        int blinky = _entityFactory.CreateEntity("blinky", PixelPosition);
                        break;
                    case 'c':
                        tileArray[y, x] = Floor;
                        int clyde = _entityFactory.CreateEntity("clyde", PixelPosition);
                        break;
                    case 'i':
                        tileArray[y, x] = Floor;
                        int inky = _entityFactory.CreateEntity("inky", PixelPosition);
                        break;
                    case 'P':
                        tileArray[y, x] = Floor;
                        int pacman = _entityFactory.CreateEntity("pacman", PixelPosition);
                        break;
                    case ' ':
                    default:
                        tileArray[y, x] = WorldTile.Floor(PixelPosition);
                        break;
                }
            }
        }
    }

    // helper metod som omvandlar Vector2 till Point koordinat 
    public static Point PixelToGrid(Vector2 pixelPosition)
    {
        return new Point(
            (int)pixelPosition.X / WorldTile.TileSize,
            (int)pixelPosition.Y / WorldTile.TileSize);
    }

    public static Vector2 GridToPixel(Point gridPosition)
    {
        return new Vector2(
        gridPosition.X * WorldTile.TileSize,
        gridPosition.Y * WorldTile.TileSize);

    }

    // tile checker 
    public static bool IsTileWalkable(int gridX, int gridY)
    {
        if (gridY < 0 || gridY >= tileArray.GetLength(0) ||
            gridX < 0 || gridX >= tileArray.GetLength(1))
        {
            return false;
        }
        // returns true 
        return tileArray[gridY, gridX].IsWalkable;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var tile in tileArray)
        {

            tile.Draw(spriteBatch);

        }

        for (int y = 0; y < tileType.GetLength(0); y++)
        {
            for (int x = 0; x < tileType.GetLength(1); x++)
            {
                // positionen top vänster av en tile t.ex X: 5 * 32 = X32 = pos, Y:5*32 = Pos
                Vector2 pixelPos = new Vector2(x * WorldTile.TileSize, y * WorldTile.TileSize);

                if (tileType[y, x] == TileType.Pellet)
                {
                    // ofset för att centrera pellet av tiles 
                    //* MATH CenterX/Y = TileSize - Texture.Width or Height / 2f   
                    float offSetX = (WorldTile.TileSize - GameAssets.TextureAssets.placeholder.Width) / 2f;
                    float offSetY = (WorldTile.TileSize - GameAssets.TextureAssets.placeholder.Height) / 2f;

                    //* Nya centrerad pos 
                    Vector2 centeredPos = new Vector2(
                        pixelPos.X + offSetX,
                        pixelPos.Y + offSetY);

                    spriteBatch.Draw(GameAssets.TextureAssets.placeholder, centeredPos, Color.Wheat);
                }
            }
        }
    }
}

//? WorldLoader
/*
* 1 GridPosition Först
* 2 PixelPosition efteråt för att få tiles att renderas på skärmen
! Entities har sin egen render system, 
! WorldLoader har uppgift att ladda in världen


*/