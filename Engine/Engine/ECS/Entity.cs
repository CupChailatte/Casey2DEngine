using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Engine.ECS;

public class Entity
{

    string name;

    public Entity(string nam)
    {
        name = nam;
        Console.WriteLine("hello " + name);

    }

    public void Initialize()
    {
        Console.WriteLine("Entity Connected ");
    }

}
