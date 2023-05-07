using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData 
{
    public CardData[,] cards;

    public bool newGame;

    public GameData(bool newGame)
    {
        cards = new CardData[4, 4];
        this.newGame = newGame;

        if (newGame)
        {
            for (int row = 0; row <= 3; row++)
                for (int column = 0; column <= 3; column++)
                    cards[row, column] =
                        new CardData();
        }
    }

}
