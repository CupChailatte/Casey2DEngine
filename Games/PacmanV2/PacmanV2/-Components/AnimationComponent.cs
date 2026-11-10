using PacmanV2.Animation; 
using PacmanV2.Components;

public class AnimationComponent : IComponent
{
    public AnimationClip CurrentClip { get; set; }
    public int CurrentFrameIndex { get; set; } = 0;  // vilken ruta man är på
    public float Timer { get; set; } = 0f; // tid för att byta ruta 
    public AnimationComponent(AnimationClip currentClip)
    {
        CurrentClip = currentClip; 

    }


}