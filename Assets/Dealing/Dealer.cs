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
    public DealingTimeStepEvent OnDealingTimeStep;
    public UnityEvent OnCardTimeReached;
    public UnityEvent OnFinishedDealing;

    private Deck deck;
    private Coroutine dealingStepCoroutine;

    private bool started = false;
    private bool paused = false;
    private bool dealNextCard = false;

    private float elapsedTime = 0f;

    public void StartDealing()
    {
        if (dealingStepCoroutine != null)
        {
            Debug.LogWarning("Dealing already started. Please stop it before starting again.");
            return;
        }

        started = true;
        DealNextCard();
    }

    public void DealNextCard()
    {
        dealNextCard = true;
    }

    public void PauseDealing()
    {
        paused = true;
    }

    public void ResumeDealing()
    {
        paused = false;
    }

    public void StopDealing()
    {
        throw new NotImplementedException();
    }

    public void ResetDeck()
    {
        deck = referenceDeck.CreateDeck();
    }

    private void Start()
    {
        deck = referenceDeck.CreateDeck();
    }

    private void Update()
    {
        if (started)
        {
            BetterDealStep();
        }
    }

    private void BetterDealStep()
    {
        if (paused)
        {
            return;
        }

        if (dealNextCard)
        {
            DealCard();
        }
        else
        {
            TimerStep();
        }
    }

    private void DealCard()
    {
        if (!deck.HasCardsRemaining())
        {
            Debug.LogWarning("There are not more cards to deal.");

            started = false;
            paused = false;
            dealNextCard = false;

            OnFinishedDealing?.Invoke();
            return;
        }

        Card cardDealt = deck.PlayCard();
        OnDrawCard?.Invoke(cardDealt);
        dealNextCard = false;
    }

    private void TimerStep()
    {
        if (elapsedTime < dealEachSecond)
        {
            elapsedTime += Time.deltaTime;
            float timeLeftPercentage = (dealEachSecond - elapsedTime) / dealEachSecond;
            OnDealingTimeStep?.Invoke(timeLeftPercentage);
        }
        else
        {
            elapsedTime = 0f;
            OnCardTimeReached?.Invoke();
        }
    }
}

[System.Serializable]
public class DrawCardEvent : UnityEvent<Card> {}
[System.Serializable]
public class DealingTimeStepEvent : UnityEvent<float> {}
