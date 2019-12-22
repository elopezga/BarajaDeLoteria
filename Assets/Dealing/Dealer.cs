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

    public DrawCardEvent OnDrawFirstCard;
    public DrawCardEvent OnDrawCard;
    public UnityEvent OnDisplayCardTimeReached;

    private Deck deck;
    private Coroutine dealingStepCoroutine;

    public void StartDealing()
    {
        this.dealingStepCoroutine = StartCoroutine(DealStep());
    }

    public void PauseDealing()
    {
        throw new NotImplementedException();
    }

    public void StopDealing()
    {
        throw new NotImplementedException();
    }

    private void Start()
    {
        deck = referenceDeck.CreateDeck();
    }

    private IEnumerator DealStep()
    {
        if (deck.HasCardsRemaining())
        {
            Card cardDealt = deck.PlayCard();
            OnDrawFirstCard?.Invoke(cardDealt);
        }

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

        this.dealingStepCoroutine = null;
    }


}

[System.Serializable]
public class DrawCardEvent : UnityEvent<Card> {}
