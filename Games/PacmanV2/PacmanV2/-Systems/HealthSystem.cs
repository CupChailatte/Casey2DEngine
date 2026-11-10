

using System;
using PacmanV2.Components;
using PacmanV2.Entity;
using PacmanV2.Events;
using PacmanV2.Systems;

public class HealthSystem : IUpdateSystem
{
    public int playerHP;
    private EntityManager _entityManager;
    public HealthSystem(EntityManager entityManager)
    {
        CollisionSystem.OnEntityCollision += HandleEntityCollisionEvent;
        _entityManager = entityManager;
    }

   
    public int GetPlayerHealth()
    {
        foreach (int entityID in _entityManager.GetEntityWithComponent<PlayerTag>())
        {
             var hp = _entityManager.GetComponent<HPComponent>(entityID); 
             return hp.CurrentHP; 
                
            
        }
        return 0; 
    }


    public void HandleEntityCollisionEvent(object sender, OnEntityCollisionEventArgs e)
    {
        foreach (int entityID in _entityManager.GetEntityWithComponent<PlayerTag>())
        {
            var health = _entityManager.GetComponent<HPComponent>(entityID);
            health.CurrentHP -= e.DamageValue;
            if (health.CurrentHP <= 0)
            {
                health.CurrentHP = 0; 
            }
        }
    }
}