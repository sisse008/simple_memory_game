using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CardData 
{
    public int spriteIndex;
    public bool isMatched;

    public CardData()
    {
        spriteIndex = -1;
        isMatched = false;
    }

    public CardData(int spriteIndex, bool isOpen, bool wasMatched)
    {
        this.spriteIndex = spriteIndex;
        this.isMatched = wasMatched;
    }

    public bool IsEqual(CardData d)
    {
        return this == d;
    }

    public bool AreMatchingCards(CardData d)
    {
        if (IsEqual(d))
            return false;
        return d.spriteIndex == spriteIndex;
    }
}
