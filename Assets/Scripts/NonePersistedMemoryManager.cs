using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonePersistedMemoryManager : IMemoryStorage
{
    public NonePersistedMemoryManager()
    { }

    public bool SaveToMemory(GameData gameData)
    {
        return true;
    }

    public GameData GetFromMemory()
    {
        return new GameData(true);
    }
}
