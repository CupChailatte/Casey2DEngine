


namespace PacmanV2.Events;


public class OnEntityCollisionEventArgs
{
    public int DamageValue;
    public OnEntityCollisionEventArgs(int damage = 1)
    {
        DamageValue = damage;
    }

}