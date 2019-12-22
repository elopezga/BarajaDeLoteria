using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : StateMachineBehaviour
{
    //public Action OnStateDealingEnter;
    public Action<AnimatorStateInfo> StateEnter;

    private const string StateKeywordDealing = "Dealing";

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.StateEnter?.Invoke(stateInfo);
        //ResolveStateEnter(stateInfo);
    }

    private void ResolveStateEnter(AnimatorStateInfo stateInfo)
    {
        if (IsInState(StateKeywordDealing, stateInfo))
        {
            //OnStateDealingEnter?.Invoke();
        }
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
