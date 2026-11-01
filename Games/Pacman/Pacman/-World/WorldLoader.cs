
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pacman.Factory;

namespace Pacman.World;

public class WorldLoader
{
    private WorldTile[,] tileArray;
    private EntityFactory factory;

    public WorldLoader(EntityFactory entityFactory)
    {
        factory = entityFactory;
    }


    public List<string> ReadMap(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        List<string> result = [];
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            result.Add(line);
            Console.WriteLine(line);
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
                Vector2 PixelPosition = new Vector2(row * 32, column * 32);

                switch (tileChar)
                {
                    case '#':
                        tileArray[row, column] = WorldTile.Wall(PixelPosition);
                        break;
                    case 'P':

                        break;
                    case 'B':

                        break;
                    case 'C':

                        break;
                    case 'O':

                        break;
                    case 'M':

                        break;
                    case 'E':

                        break;
                    case '.':
                    default:
                        tileArray[row, column] = WorldTile.Wall(PixelPosition);
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