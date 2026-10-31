using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.ECS;

// interface för system klasser 
public interface ISystem
{
     // används för klasser som ska ha laddaded grejer från redan början, annars är det Dependency Injection som används 
     void Initialize() { }
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
