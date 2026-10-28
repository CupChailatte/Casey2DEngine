
using System;

namespace Engine.ECS;

public class CheckStatusECS
{
    string Text;
    public CheckStatusECS(string text)
    {
        Text = text;
        Console.WriteLine($"Engine.ECS Connected, You Wrote : {Text}");
    }

    public void Initialize()
    {
        Console.WriteLine($"Function call works, you wrote: {Text}");
    }
}