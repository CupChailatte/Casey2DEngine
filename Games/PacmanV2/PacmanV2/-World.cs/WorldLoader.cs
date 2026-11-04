using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PacmanV2.Entity;

namespace PacmanV2.World;

public class WorldLoader
{
    public static WorldTile[,] tileArray;
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
        StreamReader reader = new StreamReader(filePath);
        List<string> readerResult = [];
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            readerResult.Add(line);
            Console.WriteLine(line);
        }
        reader.Close();
        return readerResult;
    }

    public void LoadWorld(string filePath)
    {
        List<string> lines = ReadMapFile(filePath);

        int worldWidth = lines[0].Length; // X
        int worldHeight = lines.Count; // Y

        tileArray = new WorldTile[worldHeight, worldWidth];

        for (int y = 0; y < worldHeight; y++)
        {
            for (int x = 0; x < worldWidth; x++)
            {
                char tileChar = lines[y][x]; // position av char 

                Vector2 PixelPosition = new Vector2(x * WorldTile.TileSize, y * WorldTile.TileSize);
                Point GridPosition = new Point((int)PixelPosition.X / WorldTile.TileSize, (int)PixelPosition.Y / WorldTile.TileSize);

                switch (tileChar)
                {
                    case '.':
                        tileArray[y, x] = WorldTile.Floor(PixelPosition);
                        int pellet = _entityFactory.CreatePellet("pellet", PixelPosition);
                        break;
                    case '#':
                        tileArray[y, x] = WorldTile.Wall(PixelPosition);
                        break;
                    case 'p':
                        tileArray[y, x] = WorldTile.Floor(PixelPosition);
                        int pinky = _entityFactory.CreateEntity("pinky", PixelPosition);
                        break;
                    case 'b':
                        tileArray[y, x] = WorldTile.Floor(PixelPosition);
                        int blinky = _entityFactory.CreateEntity("blinky", PixelPosition);
                        break;
                    case 'c':
                        tileArray[y, x] = WorldTile.Floor(PixelPosition);
                        int clyde = _entityFactory.CreateEntity("clyde", PixelPosition);
                        break;
                    case 'i':
                        tileArray[y, x] = WorldTile.Floor(PixelPosition);
                        int inky = _entityFactory.CreateEntity("inky", PixelPosition);
                        break;
                    case 'P':
                        tileArray[y, x] = WorldTile.Floor(PixelPosition);
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
    }
}