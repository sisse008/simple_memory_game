using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface IMemoryStorage
{
    bool SaveToMemory(GameData gameData);

    GameData GetFromMemory();
}
