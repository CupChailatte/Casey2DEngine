using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System;

namespace PacmanV2.Data;

public class EntityRegistry
{

    private readonly Dictionary<string, EntityBlueprintDTO> _entityBlueprint = [];

    // JsonSerializer = läser av json fil och omvandlar värden till användbar program objekt 
    public void LoadBlueprint(string filePath)
    {
        string json = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var data = JsonSerializer.Deserialize<Dictionary<string, EntityBlueprintDTO>>(json, options); // omvandling av json 

        if (data != null)
        {
            foreach (var kvp in data)
            {
                _entityBlueprint[key: kvp.Key] = kvp.Value; // lagrar det omvandlade värden till dictionary
            }
        }

    }
    //hämtar namnet av blueprint t.ex "pacman" 
    public EntityBlueprintDTO Get(string name)
    {
        if (_entityBlueprint.TryGetValue(name, out var entityBlueprint))
            return entityBlueprint;
        throw new KeyNotFoundException($"Blueprint {name} not found in the json file");
    }

    // omvandlar hex string färger till Monogame Color och returnerar Color. 
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