using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardsManager : MonoBehaviour
{
    public UnityEvent OnCardDiscardStart;
    public UnityEvent OnCardDiscardEnd;

    [SerializeField] private CardView cardOne;
    [SerializeField] private CardView cardTwo;

    private CardView availableCard;

    // Start is called before the first frame update
    void Start()
    {
        availableCard = cardOne;
    }

    public void HandleCardDraw(Card card)
    {
        if (IsFirstCardDraw())
        {
            availableCard = cardOne;
        }
        else
        {
            availableCard = NextCardView();
        }

        availableCard.UpdateView(card);
    }

    public void HandleCardTimeReached()
    {
        availableCard?.DiscardCard(OnCardDiscardStart.Invoke, OnCardDiscardEnd.Invoke);
    }

    public void HandleStopDealing()
    {
        cardOne.ResetToCardPile();
        cardTwo.ResetToCardPile();
    }

    private bool IsFirstCardDraw()
    {
        return availableCard == null;
    }

    private CardView NextCardView()
    {
        if (availableCard.Equals(cardOne))
        {
            return cardTwo;
        }
        else
        {
            return cardOne;
        }
    }
}
