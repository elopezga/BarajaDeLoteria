using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineManager : MonoBehaviour
{
    public Action OnStateEnterDealing;

    private const string StateKeywordDealing = "Dealing";

    public void ResolveStateEnter(AnimatorStateInfo stateInfo)
    {
        if (IsInState(StateKeywordDealing, stateInfo))
        {
            OnStateEnterDealing?.Invoke();
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
