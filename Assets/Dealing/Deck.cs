using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    private Stack<Card> remaining;
    private Stack<Card> played;

    public Deck(List<Card> cards)
    {
        remaining = new Stack<Card>(cards);
        played = new Stack<Card>();
    }

    public Card PlayCard()
    {
        Card card = remaining.Pop();
        played.Push(card);

        return card;
    }

    public bool HasCardsRemaining()
    {
        return remaining.Count > 0;
    }

    public void Shuffle()
    {
        throw new NotImplementedException();
    }
}
