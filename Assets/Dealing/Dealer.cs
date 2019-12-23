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
    public DealingTimeStepEvent OnDealingTimeStep;
    public UnityEvent OnCardTimeReached;

    private Deck deck;
    private Coroutine dealingStepCoroutine;

    public void StartDealing()
    {
        //this.dealingStepCoroutine = StartCoroutine(DealStep());
        StartCoroutine(DealCardStep());
    }

    public void DealNextCard()
    {
        StartCoroutine(DealCardStep());
    }

    public void PauseDealing()
    {
        throw new NotImplementedException();
    }

    public void StopDealing()
    {
        throw new NotImplementedException();
    }

    private void OnEnable()
    {
        //OnCardTimeReached.AddListener(DealNextCard);
    }

    private void OnDisable()
    {
        //OnCardTimeReached.RemoveListener(DealNextCard);
    }

    private void Start()
    {
        deck = referenceDeck.CreateDeck();
    }
 
    private IEnumerator DealCardStep()
    {
        if (!deck.HasCardsRemaining())
        {
            Debug.LogWarning("There are no more cards to deal.");
            yield return null;
        }
        else
        {
            Card cardDealt = deck.PlayCard();
            OnDrawCard?.Invoke(cardDealt);

            float elapsedTime = 0f;
            while (elapsedTime <= dealEachSecond)
            {
                elapsedTime += Time.deltaTime;
                float timeLeftPercentage = (dealEachSecond - elapsedTime) / dealEachSecond;
                OnDealingTimeStep?.Invoke(timeLeftPercentage);

                yield return null;
            }
            OnCardTimeReached?.Invoke();
        }
    }

    private IEnumerator DealStep()
    {
        // Only do deal step when card is placed
        if (deck.HasCardsRemaining())
        {
            Card cardDealt = deck.PlayCard();
            OnDrawFirstCard?.Invoke(cardDealt);
        }

        float elapsedTime = 0f;

        while (deck.HasCardsRemaining())
        {
            elapsedTime += Time.deltaTime;
            Debug.Log((dealEachSecond - elapsedTime)/dealEachSecond);
            float timeLeftPercentage = (dealEachSecond - elapsedTime) / dealEachSecond;
            OnDealingTimeStep?.Invoke(timeLeftPercentage);

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
[System.Serializable]
public class DealingTimeStepEvent : UnityEvent<float> {}
