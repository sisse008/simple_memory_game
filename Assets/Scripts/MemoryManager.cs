using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MemoryManager : MonoBehaviour
{
    public enum MemoryType
    {
        PLAYER_PREF = 0,
        NONE_PERSISTED = 1
    }

    public MemoryType memoryType = MemoryType.PLAYER_PREF;

    IMemoryStorage memoryStorage;

    private void OnEnable()
    {
        if (memoryType == MemoryType.PLAYER_PREF)
            memoryStorage = new PlayerPrefMemoryManager();
        else
            memoryStorage = new NonePersistedMemoryManager();
    }

    public void SaveGameData(GameData data)
    { 
        memoryStorage.SaveToMemory(data);
    }

    public GameData GetGameData()
    {
        return memoryStorage.GetFromMemory();
    }

}
