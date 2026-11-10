using PacmanV2.Entity; 
using Microsoft.Xna.Framework;
using PacmanV2.Components;

namespace PacmanV2.Systems;

public class AnimationSystem : IUpdateSystem
{
    private readonly EntityManager _entityManager;

    public AnimationSystem(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }

    public void Initialize() { }

    public void Update(GameTime gameTime)
    {
        // Delta-tid: hur många bråkdelar av en sekund som passerat sedan förra framen (t.ex. 0.016s)
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        foreach (int entityId in _entityManager.GetEntityWithComponent<AnimationComponent>())
        {
            var anim = _entityManager.GetComponent<AnimationComponent>(entityId);
            var sprite = _entityManager.GetComponent<RenderComponent>(entityId);

            if (anim?.CurrentClip == null || sprite == null)
                continue;

            // 1. Öka timern
            anim.Timer += dt;

            // 2. Har det gått 0.1 sekunder än?
            if (anim.Timer >= anim.CurrentClip.FrameDuration)
            {
                // Dra av tiden (nollställ inte helt, så vi inte tappar millisekunder)
                anim.Timer -= anim.CurrentClip.FrameDuration;

                // 3. Hoppa till nästa bildruta
                anim.CurrentFrameIndex++;

                // 4. Om vi nått slutet på serien, loopa tillbaka till 0
                if (anim.CurrentFrameIndex >= anim.CurrentClip.Frames.Length)
                {
                    anim.CurrentFrameIndex = 0;
                }
            }

            // 5. Kopiera den aktiva rutans rektangel till SpriteComponent!
            sprite.SourceRectangle = anim.CurrentClip.Frames[anim.CurrentFrameIndex];
        }
    }
}