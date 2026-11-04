using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PacmanV2.Data;
using PacmanV2.Entity;
using PacmanV2.Systems;
using PacmanV2.World;

namespace PacmanV2;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private EntityManager _entityManager;
    private EntityRegistry _entityRegistry;
    private EntityFactory _entityFactory;

    private RenderSystem _renderSystem;
    private GridMovementSystem _movementSystem;
    private WorldLoader _worldLoader;
    private InputSystem _inputSystem;
    private CollisionSystem _collisionSystem;
    private ScoreSystem _scoreSystem;
    private UISystem _UISystem;
    private GameStateSystem _gameStateSystem;
    public const int TopUIPadding = 80;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferHeight = 1000 + TopUIPadding;
        _graphics.PreferredBackBufferWidth = 900;
        _graphics.ApplyChanges();
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _entityManager = new EntityManager();
        _entityRegistry = new EntityRegistry();

        _movementSystem = new GridMovementSystem(_entityManager);
        _renderSystem = new RenderSystem(_entityManager);
        _inputSystem = new InputSystem(_entityManager);
        _scoreSystem = new ScoreSystem();
        _UISystem = new UISystem(_scoreSystem);


        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        GameAssets.TextureAssets.LoadTextures(Content);
        _entityFactory = new EntityFactory(_entityManager, _entityRegistry, _worldLoader);

        _worldLoader = new WorldLoader(_entityManager, _entityFactory);
        _collisionSystem = new CollisionSystem(_entityManager, _worldLoader);
        _gameStateSystem = new GameStateSystem(_entityManager, _worldLoader);


        _entityRegistry.LoadBlueprint("-Data/Entities.json");
        _worldLoader.LoadWorld("Content/maze1.csv");

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        _inputSystem.Update(gameTime);
        _movementSystem.Update(gameTime);
        _collisionSystem.Update(gameTime);
        _scoreSystem.Update(gameTime);
        _gameStateSystem.StateChanger();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();
        _worldLoader.Draw(_spriteBatch);
        _renderSystem.Draw(_spriteBatch);
        _UISystem.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
