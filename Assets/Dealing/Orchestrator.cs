using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orchestrator : MonoBehaviour
{
    [SerializeField] private Dealer dealer;
    [SerializeField] private CardsManager cardsManager;
    [SerializeField] private UIController uiController;
    [SerializeField] private StateMachineManager stateMachine;

    private void OnEnable()
    {
        stateMachine.OnStateEnterDealing += dealer.StartDealing;

        dealer.OnDrawCard.AddListener(cardsManager.HandleCardDraw);
        dealer.OnCardTimeReached.AddListener(cardsManager.HandleCardTimeReached);
        dealer.OnDealingTimeStep.AddListener(uiController.UpdateTimeIndicator);

        cardsManager.OnCardDiscardEnd.AddListener(dealer.DealNextCard);
    }

    private void OnDisable()
    {
        stateMachine.OnStateEnterDealing -= dealer.StartDealing;

        dealer.OnDrawCard.RemoveListener(cardsManager.HandleCardDraw);
        dealer.OnCardTimeReached.RemoveListener(cardsManager.HandleCardTimeReached);
        dealer.OnDealingTimeStep.RemoveListener(uiController.UpdateTimeIndicator);

        cardsManager.OnCardDiscardEnd.RemoveListener(dealer.DealNextCard);
    }
}
