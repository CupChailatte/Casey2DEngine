
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Engine.Components;
using Engine.ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pacman.Factory;

namespace Pacman.World;

public class WorldLoader
{
    private WorldTile[,] tileArray;
    private EntityFactory _entityfactory;
    private EntityManager _entityManager;
    public WorldLoader(EntityFactory entityFactory, EntityManager entityManager)
    {
        _entityfactory = entityFactory;
        _entityManager = entityManager;
    }

    public List<string> ReadMap(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        List<string> result = [];
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            result.Add(line);
            // Console.WriteLine(line);
        }
        reader.Close();
        return result;
    }

    public void LoadWorld(string filePath)
    {
        List<string> lines = ReadMap(filePath);

        int worldWidth = lines[0].Length; // X  
        int worldHeight = lines.Count; // Y 

        tileArray = new WorldTile[worldHeight, worldWidth]; // 2D array = row major 
        for (int row = 0; row < worldHeight; row++)
        {
            for (int column = 0; column < worldWidth; column++)
            {
                char tileChar = lines[row][column]; // speficik charactär från fil 
                Vector2 PixelPosition = new Vector2(column * 32, row * 32);


                switch (tileChar)
                {
                    case 'P':
                        tileArray[row, column] = WorldTile.Floor(PixelPosition);
                        int pacman = _entityfactory.SpawnTestPacman(PixelPosition);
                        break;
                    case '#':
                        tileArray[row, column] = WorldTile.Wall(PixelPosition);
                        break;
                    case '.':
                    default:
                        tileArray[row, column] = WorldTile.Floor(PixelPosition);
                        break;
                }
            }
        }
    }

    // helper metod som omvandlar pixelPosition till gridposition 
    public Point GetGridPosition(Vector2 pixelPosition)
    {
        int targetX = (int)pixelPosition.X / WorldTile.TileSize;
        int targetY = (int)pixelPosition.Y / WorldTile.TileSize;
        return new Point(targetX, targetY);
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var tile in tileArray)
        {
            tile.Draw(spriteBatch);
        }
    }
}