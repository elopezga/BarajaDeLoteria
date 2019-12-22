using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    [SerializeField] private CardView cardOne;
    [SerializeField] private CardView cardTwo;

    private CardView availableCard;

    // Start is called before the first frame update
    void Start()
    {
        //availableCard = cardOne;
    }

    public void HandleFirstCardDraw(Card card)
    {
        availableCard = cardOne;
        availableCard.UpdateView(card);
    }

    public void HandleCardDraw(Card card)
    {
        Action updateNextCard = () => {
            if (availableCard.Equals(cardOne))
            {
                availableCard = cardTwo;    
            }
            else
            {
                availableCard = cardOne;
            }

            availableCard.UpdateView(card);
        };

        availableCard.DiscardCard(updateNextCard);        
    }
}
