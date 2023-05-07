using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CardController : MonoBehaviour, IPointerClickHandler
{
    public static UnityAction<CardController> cardSelected;

    public Image content;
    public Image back;

    [SerializeField] bool isOpen;
    [SerializeField] bool isMatched;

    public bool IsOpen => isOpen;
    public bool IsMatched => isMatched;

    CardData myCardData;
    int spriteIndex;


    public static bool DoCardsMatch(CardController card1, CardController card2)
    {
        return card1.spriteIndex == card2.spriteIndex;
    }

    public void InitCard(CardData _cardData)
    {
        myCardData = null;

        content.sprite = GameManager.Instance.GetSpriteFromIndex(_cardData.spriteIndex);

        if (_cardData.isMatched)
        {
            OpenCard();
            SetMatched();
        }
        else
        {
            CloseCard();
            SetUnmatched();
        }
           

        myCardData = _cardData;
        spriteIndex = _cardData.spriteIndex;
    }

    public void CloseCard()
    {
        content.enabled = false;
        back.enabled = true;

        isOpen = false;

        SetUnmatched();

        UpdateCardData();
    }

    public void OpenCard()
    {
        content.enabled = true;
        back.enabled = false;

        isOpen = true;

        UpdateCardData();
    }

    public void OnPointerClick(PointerEventData eventData)
    { 
        cardSelected?.Invoke(this);
    }

    public void SetMatched()
    {
        isMatched = true;
        content.color = Color.green;
        UpdateCardData();

    }

    public void SetUnmatched()
    {
        isMatched = false;
        content.color = new Color(255, 255, 255, 1f);
        UpdateCardData();
    }

    void UpdateCardData()
    {
        if (myCardData == null)
            return;
        myCardData.isMatched = isMatched;
    }

}
