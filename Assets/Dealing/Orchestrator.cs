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
        stateMachine.OnStateEnterPaused += dealer.PauseDealing;
        stateMachine.OnStateExitPaused += dealer.ResumeDealing;

        dealer.OnDrawCard.AddListener(cardsManager.HandleCardDraw);
        dealer.OnCardTimeReached.AddListener(cardsManager.HandleCardTimeReached);
        dealer.OnDealingTimeStep.AddListener(uiController.UpdateTimeIndicator);
        dealer.OnFinishedDealing.AddListener(stateMachine.GoToStateStart);

        cardsManager.OnCardDiscardEnd.AddListener(dealer.DealNextCard);
        uiController.PauseButton.AddListener(HandlePause);
        uiController.MenuController.AddListenerOnStartClick(HandleStartClicked);
    }

    private void OnDisable()
    {
        stateMachine.OnStateEnterDealing -= dealer.StartDealing;
        stateMachine.OnStateEnterPaused -= dealer.PauseDealing;
        stateMachine.OnStateExitPaused -= dealer.ResumeDealing;

        dealer.OnDrawCard.RemoveListener(cardsManager.HandleCardDraw);
        dealer.OnCardTimeReached.RemoveListener(cardsManager.HandleCardTimeReached);
        dealer.OnDealingTimeStep.RemoveListener(uiController.UpdateTimeIndicator);
        dealer.OnFinishedDealing.RemoveListener(stateMachine.GoToStateStart);

        cardsManager.OnCardDiscardEnd.RemoveListener(dealer.DealNextCard);
        uiController.PauseButton.RemoveListener(HandlePause);
        uiController.MenuController.RemoveListenerOnStartClick(HandleStartClicked);
    }

    private void HandlePause()
    {
        if (stateMachine.IsInPauseState())
        {
            stateMachine.GoToStateDealing();
        }
        else
        {
            stateMachine.GoToStatePause();
        }
    }

    private void HandleStartClicked()
    {
        stateMachine.GoToStateDealing();
    }


}
