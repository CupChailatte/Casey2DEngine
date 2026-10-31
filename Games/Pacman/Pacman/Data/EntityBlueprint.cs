
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Pacman.Data;

//? DTO = DATA TRANSFER OBJECT 
/// <summary>
///  * DTO är en lätt objek som används för att tranfera data mellan lagern i ett program
///  * Innehåller bara data och ingen logik. 
///  * Används för att separera Data ifrån Logik. 
/// </summary>

public class Vector2DTO
{
    public float X { get; set; } = 1f;
    public float Y { get; set; } = 1f;
}

public class EntityBlueprint
{
    public float Speed { get; set; } = 0f;
    public Vector2DTO Scale { get; set; }
    public string Color { get; set; } = "#FFFFFFF";
    public string GhostType { get; set; }
    public int Points { get; set; } = 0;
}