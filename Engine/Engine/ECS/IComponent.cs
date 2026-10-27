using Microsoft.Xna.Framework; 

namespace Engine.ECS; 
public interface IComponent
{
    //! corrected my code: I should not have functions for IComponent, 
    // * Instead, i kept it empty for data contract or a marker --> able to use it for e.g List or Dictionary
    // public void Initialize(){}
    // public void Update(GameTime gameTime){}
    // public void Draw(SpriteBatch spriteBatch){}

}