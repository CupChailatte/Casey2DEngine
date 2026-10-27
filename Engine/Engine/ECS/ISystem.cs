using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics; 

namespace Engine.ECS; 

// interface för system klasser 
public interface ISystem
{
    // använder för att one time init av objects 
     void Initialize();     
}

// System som tar hand om uppdatering av t.ex UI, AUDIO, Movement, Events, Collision 
public interface IUpdateSystem : ISystem
{
     void Update(GameTime gameTime); 
}

// System som ska renderar grafik t.ex SpriteRenderer, UIRenderer, DebugRenderer
public interface IRenderSystem : ISystem
{
     void Draw(SpriteBatch spriteBatch); 
}


/* first attempt to write 
public interface ISystem
{
    public void Initialize(){}
    public void Update(GameTime gameTime){}
    public void Darw(SpriteBatch spriteBatch){}
}
*/
