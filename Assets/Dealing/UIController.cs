using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    public PauseButton PauseButton;

    [SerializeField] private Image timeIndicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTimeIndicator(float percentage)
    {
        timeIndicator.fillAmount = percentage;
    }
}
