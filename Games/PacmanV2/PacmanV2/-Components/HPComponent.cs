

namespace PacmanV2.Components;

public class HPComponent : IComponent
{
    public int MaxHp;
    public int CurrentHP;
    public bool IsVulnerable;

    public HPComponent(int maxHp = 3, bool isVulnerable = false)
    {
        MaxHp = maxHp;
        CurrentHP = MaxHp;
        IsVulnerable = isVulnerable; // när pacman äter en powerepellet, används för att göra spöken ätbar. 
    }
}