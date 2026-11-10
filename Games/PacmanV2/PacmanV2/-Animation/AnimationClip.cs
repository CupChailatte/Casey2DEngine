using Microsoft.Xna.Framework;

namespace PacmanV2.Animation;

public class AnimationClip
{
    // Rektanglarna på spritesheetet: t.ex. [ (0,0,16,16), (16,0,16,16), (32,0,16,16) ]
    public Rectangle[] Frames { get; set; }
    
    // Hur länge varje ruta visas (0.1f = 10 bilder i sekunden)
    public float FrameDuration { get; set; }

    public AnimationClip(Rectangle[] frames, float frameDuration = 0.1f)
    {
        Frames = frames;
        FrameDuration = frameDuration;
    }
}