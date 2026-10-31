
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Pacman.Data;

/// <summary>
/// ? Registryn är den som läser från JSON filen och hämtar värden samt parsar(gör om värden till logik)
/// </summary>

public class BlueprintRegistry
{
    private readonly Dictionary<string, EntityBlueprint> _blueprint = [];

    public void Load(string filePath)
    {
        string jsonFile = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var data = JsonSerializer.Deserialize<Dictionary<string, EntityBlueprint>>(jsonFile, options);

        if (data != null)
        {
            foreach (var keyValuePair in data)
            {
                _blueprint[key: keyValuePair.Key] = keyValuePair.Value;
            }
        }

    }

    public EntityBlueprint Get(string name)
    {
        if (_blueprint.TryGetValue(name, out var blueprint))
            return blueprint;

        throw new KeyNotFoundException($"Blueprint: '{name}', was not found in registry");
    }

    // Hjälpar metod som omvandlar HEX färg till Monogame Color struct 
    public static Color ParseColor(string hexColor)
    {

        if (hexColor.StartsWith('#')) hexColor = hexColor.Substring(1);

        byte r = Convert.ToByte(hexColor.Substring(0, 2), 16);
        byte g = Convert.ToByte(hexColor.Substring(2, 2), 16);
        byte b = Convert.ToByte(hexColor.Substring(4, 2), 16);

        return new Color(r, g, b);

    }
}



/*
? JsonSerializer - Omvandlar mellan program objekt och JSON strings. 

? Serialize - Omvandlar till JSON 
 * Gör om objekt och omvandlar den egenskaper/properties och värden till JSON format t.ex: 
 * string jsonString = JsonSerializer.Serialize(MinObjekt);  
? Deserialize - Omvandlar till program objekt 
 * Gör om JSON strings till strongly types program objekt 
 * t.ex: MyClass obj = JsonSerializer.Deserialize<MyClass>(jsonString);





*/