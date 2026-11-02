
using Engine.ECS;
using Engine.Enums; 
using Microsoft.Xna.Framework;

namespace Engine.Components;

public class GridMovementComponent : IComponent
{
    public Point Direction {get;set;} = Point.Zero; // sätts i input system 
    public Point CurrentGridPosition {get; set;} 
    public Point NextGridPosition {get; set;} 

    public Vector2 PixelPosition {get; set;}
    public Vector2 CurrentPixelPosition {get; set;} = Vector2.Zero; 
    public Vector2 NextPixelPosition {get; set;}  = Vector2.Zero; 
    
    public EntityDirection entityDirection {get;set;} = EntityDirection.Right; 
    public float Speed {get; set;}
    public float MoveProgress {get;set;}
   
    public bool IsMoving  {get;set;}
    public int TileSize {get;set;}


    public GridMovementComponent(Point startGridPosition, float speed, int tileSize)
    {
        // sätter grid positionen(logik)
        CurrentGridPosition = startGridPosition; 
        NextGridPosition = CurrentGridPosition; 
        Speed = speed; 
        TileSize = tileSize; 

        // sätter pixel positionen (grafik/render) 
        PixelPosition = new Vector2(CurrentGridPosition.X * TileSize, CurrentGridPosition.Y * TileSize);
        CurrentPixelPosition = PixelPosition; 
        NextPixelPosition = PixelPosition; 

        
    } 
}