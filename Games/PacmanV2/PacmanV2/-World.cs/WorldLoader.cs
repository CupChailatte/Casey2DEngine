using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PacmanV2.Entity;

namespace PacmanV2.World;

public class WorldLoader
{
    private WorldTile[,] tileArray;
    private EntityManager _entityManager;
    private EntityFactory _entityFactory;
    public WorldLoader(EntityManager entityManager, EntityFactory entityFactory)
    {
        _entityManager = entityManager;
        _entityFactory = entityFactory;
    }

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

                switch (tileChar)
                {
                    case '#':
                        tileArray[y, x] = WorldTile.Wall(PixelPosition);
                        break;
                    case '.':
                    default:
                        tileArray[y, x] = WorldTile.Floor(PixelPosition);
                        break;
                }
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var tile in tileArray)
        {
            tile.Draw(spriteBatch);
        }
    }
}