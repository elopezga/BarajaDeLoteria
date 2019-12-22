using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateReporter : StateMachineBehaviour
{
    //public StateEnterEvent StateEnter;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<StateMachineManager>().ResolveStateEnter(stateInfo);
    }
}

[Serializable]
public class StateEnterEvent : UnityEvent<AnimatorStateInfo> { }