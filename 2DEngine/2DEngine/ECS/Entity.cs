

public class Entity
{
    public string Text; 
    public Entity(string text)
    {
        Text = text; 
    }

    public void Initialize()
    {
        Console.Write($"2D Engine Connected \n" + $"You wrote: {Text}"); 
    }
}