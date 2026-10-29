using System.Numerics;
using Engine.Component;
using Engine.ECS;
using Engine.Systems;

namespace Pacman.Factory;

//? Factory Design Pattern 
//! Uppgift: bara ASSEMBLA COMPONENTS till entities inget annat 

public class EntityFactory
{

    private readonly EntityContainer _entities; // Dependency Injection 

    public EntityFactory(EntityContainer entities)
    {
        _entities = entities;
    }

    public int CreatePacman(Vector2 startPosition)
    {
        int _pacman = _entities.CreateEntity(); // createEntity returnar 1 (id för pacman)

        Vector2 scale = new Vector2(32, 32);
        float rotation = 0f;

        var tranform = new TransformComponent(startPosition, rotation, scale);
        var sprite = new RenderComponent(GameAssets.TextureAsset.pacman);

        _entities.AddComponent(_pacman, tranform);
        _entities.AddComponent(_pacman, sprite);

        return _pacman;
    }


    public int CreatePinky(Vector2 startPosition)
    {
        int Pinky = _entities.CreateEntity();

        Vector2 scale = new Vector2(32, 32);
        float rotation = 0f;

        var tranform = new TransformComponent(startPosition, rotation, scale);

    }

}