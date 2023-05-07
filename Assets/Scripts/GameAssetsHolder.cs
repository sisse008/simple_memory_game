using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameAssetsHolder", menuName = "ScriptableObjects/GameAssetsHolder", order = 1)]
public class GameAssetsHolder : ScriptableObject
{
    public List<Sprite> cardSprites;

    public List<Sprite> Sprites => new List<Sprite>(cardSprites);
}
