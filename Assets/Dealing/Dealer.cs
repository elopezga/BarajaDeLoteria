using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dealer : MonoBehaviour
{
    [SerializeField] private DeckScriptableObject referenceDeck;
    [SerializeField] private float dealEachSecond = 4f;

    public DrawCardEvent OnDrawCard;

    private Deck deck;

    private void Start()
    {
        deck = referenceDeck.CreateDeck();

        StartCoroutine(DealStep());
    }

    private IEnumerator DealStep()
    {
        float elapsedTime = 0f;

        while (deck.HasCardsRemaining())
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= dealEachSecond)
            {
                elapsedTime = 0f;
                Card cardDealt = deck.PlayCard();
                OnDrawCard?.Invoke(cardDealt);
            }

            yield return null;
        }
    }


}

[System.Serializable]
public class DrawCardEvent : UnityEvent<Card> {}
