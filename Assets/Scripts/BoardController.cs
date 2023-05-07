using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardController : MonoBehaviour
{

    public CardController[] gameCards;

    CardController selected1;
    CardController selected2;

    bool freezeBoard;


    private void OnEnable()
    {
        CardController.cardSelected += UpdateBoard;
    }

    private void OnDisable()
    {
        CardController.cardSelected -= UpdateBoard;
    }

    public void SetGameBoard(GameData gameData)
    {
        selected1 = null;
        selected2 = null;   

        freezeBoard = false;

        for (int row = 0; row <= 3; row++)
            for (int column = 0; column <= 3; column++)
                gameCards[4 * row + column].InitCard(
                    gameData.cards[row, column]);
    }


    //List<CardController> OpenCards() => gameCards.Where(card => card.IsOpen).ToList();


    void CheckMatch()
    {
        if (selected1 == null || selected2 == null)
        {
            Debug.LogError("need to select two cards to check match");
            return;
        }

        if (CardController.DoCardsMatch(selected1, selected2))
        {
            selected1.SetMatched();
            selected2.SetMatched();
        }
        else 
        {
            selected1.CloseCard();
            selected2.CloseCard();
        }


        selected1 = null;
        selected2 = null;
    }

    IEnumerator DisplaySelectedCardsAndCheckMatch(float secs)
    {
        freezeBoard = true;
        yield return new WaitForSeconds(secs);
        CheckMatch();
        freezeBoard = false;
    }

    void UpdateBoard(CardController card)
    {
        if (freezeBoard)
            return;

        if (card.IsOpen == false)
        {
            if (selected1 == null)
            {
                selected1 = card;
                card.OpenCard();
                return;
            }
            if (selected2 == null)
            {
                selected2 = card;
                card.OpenCard();
                StartCoroutine(DisplaySelectedCardsAndCheckMatch(1f));
            }
        }
        else 
        {
            if (selected1 == card)
            {
                card.CloseCard();
                selected1 = null;
            }
        }
    }

  
}
