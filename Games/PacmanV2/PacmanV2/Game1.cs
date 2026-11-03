using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PacmanV2.Data;
using PacmanV2.Entity;
using PacmanV2.World;

namespace PacmanV2;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private EntityManager _entityManager;
    private EntiyRegistry _entityRegistry;
    private EntityFactory _entityFactory;
    private WorldLoader _worldLoader;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferHeight = 1000;
        _graphics.PreferredBackBufferWidth = 900;
        _graphics.ApplyChanges();
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _entityManager = new EntityManager();
        _entityRegistry = new EntiyRegistry();
        _entityFactory = new EntityFactory(_entityManager, _entityRegistry);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        GameAssets.TextureAssets.LoadTextures(Content);
        _entityRegistry.LoadBlueprint("-Data/Entities.json");


        _worldLoader = new WorldLoader(_entityManager, _entityFactory);
        _worldLoader.LoadWorld("Content/maze1.csv");

        int pacman = _entityFactory.SpawnPacman(new Point(2, 2)); // no render system yet!; 
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
        _worldLoader.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
