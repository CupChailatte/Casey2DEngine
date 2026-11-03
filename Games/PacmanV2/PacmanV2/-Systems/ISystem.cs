
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacmanV2.Systems;

public interface ISystem
{
    void Initialize() { }
}

// för systems 
public interface IUpdateSystem : ISystem
{
    void Update(GameTime gameTime) { }
}
// för draw/render systems 
public interface IRenderSystem : ISystem
{
    void Draw(SpriteBatch spriteBatch) { }
}