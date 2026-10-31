using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.ECS;
using Engine.Components;
using Engine.Systems;
using Pacman.Factory;
using System;
using Pacman.Data;

namespace Pacman;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private EntityManager _entityManager;
    private EntityFactory _entityFactory;

    private RenderSystem _renderSystem;
    private InputSystem _inputSystem;
    private MovementSystem _movementSystem;

    private BlueprintRegistry _blueprintRegistry;

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
        // --- ENTITIES --- 
        _blueprintRegistry = new BlueprintRegistry();
        _entityManager = new EntityManager();
        _entityFactory = new EntityFactory(_entityManager, _blueprintRegistry);

        // --- SYSTEMS --- 
        _inputSystem = new InputSystem(_entityManager);
        _movementSystem = new MovementSystem(_entityManager);
        _renderSystem = new RenderSystem(_entityManager);
        _renderSystem.Initialize();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        GameAssets.TextureAsset.LoadTextureAssets(Content);
        _blueprintRegistry.Load("Content/Data/entities.json");

        _pixelTexture = new Texture2D(GraphicsDevice, 1, 1);
        _pixelTexture.SetData(new[] { Color.White });

        // int pacman = _entityFactory.CreatePacman(new Vector2(10, 10));
        int pacboy = _entityFactory.SpawnPacman(new Vector2(10, 10));


    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        _inputSystem.Update();
        _movementSystem.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // förbygger suddig sprites
        _spriteBatch.Begin(
        sortMode: SpriteSortMode.Deferred,
        blendState: BlendState.AlphaBlend,
        samplerState: SamplerState.PointClamp,
        depthStencilState: DepthStencilState.None,
        rasterizerState: RasterizerState.CullCounterClockwise
    );
        _renderSystem.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
