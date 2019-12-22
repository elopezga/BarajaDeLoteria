using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateEventListener : MonoBehaviour
{
    [SerializeField] private StateMachineManager stateMachineManager;
    [SerializeField] private UnityEvent OnStateEnterDealing;

    // Start is called before the first frame update
    private void OnEnable()
    {
        stateMachineManager.OnStateEnterDealing += OnStateEnterDealing.Invoke;
    }

    private void OnDisable()
    {
        stateMachineManager.OnStateEnterDealing -= OnStateEnterDealing.Invoke;
    }
}
