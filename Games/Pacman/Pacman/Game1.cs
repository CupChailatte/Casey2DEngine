using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.ECS;
using Engine.Component;
using Engine.Systems;
using Pacman.Factory;
using System;

namespace Pacman;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private EntityManager _entityManager;
    private EntityFactory _entityFactory;

    private RenderSystem _renderSystem;

    private Texture2D _pixelTexture;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = 1000,
            PreferredBackBufferHeight = 1000
        };
        _graphics.ApplyChanges();
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _entityManager = new EntityManager();
        _entityFactory = new EntityFactory(_entityManager);

        _renderSystem = new RenderSystem(_entityManager);
        _renderSystem.Initialize();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        GameAssets.TextureAsset.LoadTextureAssets(Content);

        _pixelTexture = new Texture2D(GraphicsDevice, 1, 1);
        _pixelTexture.SetData(new[] { Color.White });

        int pacman = _entityFactory.CreatePacman(new Vector2(10, 10));
        bool HasComponent = _entityManager.HasComponent<RenderComponent>(pacman);
        Console.WriteLine(HasComponent);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();
        _renderSystem.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
