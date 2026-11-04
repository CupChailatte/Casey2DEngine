

using System;
using PacmanV2.Entity;
using PacmanV2.Systems;
using PacmanV2.World;

public class GameStateSystem : ISystem
{
    private EntityManager _entityManager;
    private WorldLoader _worldLoader;

    public GameStateSystem(EntityManager entityManager, WorldLoader worldLoader)
    {
        _entityManager = entityManager;
        _worldLoader = worldLoader;
    }

    public void StateChanger()
    {
        if (_worldLoader.GetPelletAmount() == 0)
        {
            Console.WriteLine("You win");
        }
    }

}