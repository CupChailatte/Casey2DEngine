
using Microsoft.Xna.Framework;

namespace PacmanV2.Data;

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

public class EntityBlueprintDTO
{
    public float Speed { get; set; }
    public Vector2DTO Scale { get; set; }
    public string Color { get; set; } = "#FFFFFF";
    public string GhostType { get; set; }
    public int Points { get; set; } = 0;

}

