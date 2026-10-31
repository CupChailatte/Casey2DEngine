using System;
using System.Collections.Generic;

namespace Engine.ECS;

public class EntityManager
{
    private int _nextEntityID = 1;
    // HashSet som håller koll på levande entities : HashSet<T> Är en generisk samling av UNIKA VÄRDEN utan nyckel-värde par. O(1) lookup 
    private readonly HashSet<int> _activeEntities = new();
    // Dictionary/ min collection av componenter med key-value pair. Dictionary<T> är en generisk samling av key-value pair baserad på Hashtabell, där varje unik nyckel pekar på ett speficik tillhörande värde.O(1) lookup
    // int = entityID, IComponent = komponenten 
    private readonly Dictionary<Type, Dictionary<int, IComponent>> _componentCollection = new();

    //* Skapar bara entities med nummering t.ex entity 1 = 1, entity 2 = 2 
    public int CreateEntity()
    {
        int entityID = _nextEntityID++;
        _activeEntities.Add(entityID);
        return entityID;
    }

    //* förstör entities : använder för att ta bort entites när de ska t.ex dö. 
    //* Tar också bort componenterna från collection --> förebygga leaks.
    public void DestroyEntity(int entityID)
    {
        if (!_activeEntities.Remove(entityID)) return; // om jag försöker att förstöra en entity som inte finns, return. 
        // går igenom Dictionary värden
        foreach (var hashTable in _componentCollection.Values)
        {
            hashTable.Remove(entityID);
        }
    }

    //note 'T' är en platshållare för en generisk typ 
    //* Lägger till components till _componentCollection 
    public void AddComponent<T>(int entityID, T component) where T : IComponent
    {
        // Kollar om entity finns 
        if (!_activeEntities.Contains(entityID))
        {
            throw new ArgumentException($"EntityId: {entityID}, does not exist!");
        }

        Type type = typeof(T);

        if (!_componentCollection.TryGetValue(type, out var newComponent))
        {
            newComponent = new Dictionary<int, IComponent>();
            _componentCollection[type] = newComponent;
        }
        newComponent[entityID] = component;
    }

    //* Hämtar component genom entityID. Om component inte finns return null 
    public T GetComponent<T>(int entityID) where T : class, IComponent
    {
        // hämtar komponenten från Dictionary och lagrar resultatet i storedComponent, sedan returnar värdet(component)
        if (_componentCollection.TryGetValue(typeof(T), out var storedComponent) &&
             storedComponent.TryGetValue(entityID, out var component))
        {
            return (T)component;
        }
        return null;
    }


    //* används för att kolla om en entity har en viss komponent : returnar sant/falsk : O(1) lookup 
    public bool HasComponent<T>(int entityID) where T : IComponent
    {
        return _componentCollection.TryGetValue(typeof(T), out var storedComponent) &&
               storedComponent.ContainsKey(entityID);
        // koden hämtar typ-objektet T(typeOf(T)),
        // letar upp lagrings plats för värden i Dictionary 
        // lägger resultatet i en ny variabel som heter "storedComponent" 
        // storedComponent.ContainsKey() kollar om komponenten finns
    }

    //* ta bort en specifik komponent från en entity. 
    public void RemoveComponent<T>(int entityID) where T : IComponent
    {
        // hämtar componenten och sedan tar bort den från entityID som den tillhörde 
        Type type = typeof(T);
        if (_componentCollection.TryGetValue(type, out var componentToRemove))
        {
            componentToRemove.Remove(entityID);
        }
    }

    // metod som ska returna alla entityID som har ett viss komponent
    public IEnumerable<int> GetEntityWithComponent<T>() where T : IComponent
    {
        // hämtar componenten och returnas komponentens nyckel par 
        if (_componentCollection.TryGetValue(typeof(T), out var component))
        {
            return component.Keys;
        }
        return Array.Empty<int>(); // inbygd statisk metod i .Net som returnar en tom array av typen int 
    }

}
