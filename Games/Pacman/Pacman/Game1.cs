using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.ECS;
using Engine.Component;

namespace Pacman;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private EntityContainer entity1;
    private RenderSystem _renderSystem;
    private Texture2D _pixelTexture;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        entity1 = new EntityContainer();
        _renderSystem = new RenderSystem(entity1);
        _renderSystem.Initialize();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _pixelTexture = new Texture2D(GraphicsDevice, 1, 1);
        _pixelTexture.SetData(new[] { Color.White });

        int pacman = entity1.CreateEntity();
        entity1.AddComponent(pacman, new TransformComponent(
        position: new Vector2(200, 100),
        rotation: 0f,
        scale: new Vector2(32, 32)));

        entity1.AddComponent(pacman, new RenderComponent(_pixelTexture)
        {
            Color = Color.Yellow
        });
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        _renderSystem.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
