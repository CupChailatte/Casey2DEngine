using System; 

namespace Engine.ECS;

public class Entity
{
    string text;
    public Entity(string txt)
    {
        text = txt; 
        Console.WriteLine($"The Engine is connected to the project \n" + $"You wrote {text}");
    }

    public void Initialize()
    {
        Console.WriteLine($"Function Test: You wrote {text}"); 
        
    }
}