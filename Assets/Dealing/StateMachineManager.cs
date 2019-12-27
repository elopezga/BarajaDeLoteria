using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineManager : MonoBehaviour
{
    public Action OnStateEnterDealing;
    public Action OnStateEnterPaused;
    public Action OnStateExitPaused;

    private const string StateKeywordDealing = "StartDealing";
    private const string StateKeywordPaused = "Pause";

    private Animator animator;
    private AnimatorStateInfo currentStateInfo;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ResolveStateEnter(AnimatorStateInfo stateInfo)
    {
        currentStateInfo = stateInfo;

        if (IsInState(StateKeywordDealing, stateInfo))
        {
            OnStateEnterDealing?.Invoke();
        }
        else if (IsInState(StateKeywordPaused, stateInfo))
        {
            OnStateEnterPaused?.Invoke();
        }
    }

    public void ResolveStateExit(AnimatorStateInfo stateInfo)
    {
        if (IsInState(StateKeywordDealing, stateInfo))
        {
            
        }
        else if (IsInState(StateKeywordPaused, stateInfo))
        {
            OnStateExitPaused?.Invoke();
        }
    }

    public void GoToStateStart()
    {
        animator.SetTrigger("GoToStartState");
    }

    public void GoToStatePause()
    {
        animator.SetTrigger("GoToPauseState");
    }

    public void GoToStateDealing()
    {
        animator.SetTrigger("GoToDealingState");
    }

    public bool IsInPauseState()
    {
        return IsInState(StateKeywordPaused, currentStateInfo);
    }

    private bool IsInState(string stateName, AnimatorStateInfo stateInfo)
    {
        return stateInfo.IsName(ConstructFullStateName(stateName));
    }

    private string ConstructFullStateName(string stateName)
    {
        return $"Base Layer.{stateName}";
    }
}
