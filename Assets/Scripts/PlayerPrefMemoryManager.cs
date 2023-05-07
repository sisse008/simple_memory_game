using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefMemoryManager : IMemoryStorage
{
    const string spriteKeyCode = "SPRITE_INDEX";
    const string isOpenKeyCode = "IS_OPEN_BOOL";
    const string isMatchedKeyCode = "IS_MATCHED_BOOL";

    string SpriteKeyCode(int row, int column) => spriteKeyCode + row.ToString()+column.ToString();
    string IsOpenKeyCode(int row, int column) => isOpenKeyCode + row.ToString()+column.ToString();
    string IsMatchedKeyCode(int row, int column) => isMatchedKeyCode + row.ToString()+column.ToString();
    public PlayerPrefMemoryManager()
    { }

    public bool SaveToMemory(GameData gameData)
    {
        for (int row = 0; row <= 3; row++)
        {
            for (int column = 0; column <= 3; column++)
            {
                MemoryAPI.SetInt(gameData.cards[row, column].spriteIndex, SpriteKeyCode(row,column));
                MemoryAPI.SetBool(gameData.cards[row, column].isMatched, IsMatchedKeyCode(row,column));
            }
        }

        return true;
    }

    public GameData GetFromMemory()
    {
        GameData gameData = new GameData(false);

        for (int row = 0; row <= 3; row++)
        {
            for (int column = 0; column <= 3; column++)
            {
                int sprite_index = MemoryAPI.GetInt(SpriteKeyCode(row, column));
                if (sprite_index == -1)
                    return new GameData(true); //if error in data retrieved; start a new game

                gameData.cards[row, column] =
                   new CardData(sprite_index,
                       MemoryAPI.GetBool(IsOpenKeyCode(row, column)),
                       MemoryAPI.GetBool(IsMatchedKeyCode(row, column)));
            }    
        }
           
        return gameData;
    }
}
