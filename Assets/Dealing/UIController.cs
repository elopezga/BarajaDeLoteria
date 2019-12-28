using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    public PauseButton PauseButton;
    public MenuController MenuController;
    public Button StopButton;

    [SerializeField] private Image timeIndicator;

    // Start is called before the first frame update
    void Start()
    {
        HideTimeIndicator();
        PauseButton.Hide();
        StopButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideStopButton()
    {
        StopButton.gameObject.SetActive(false);
    }

    public void ShowStopButton()
    {
        StopButton.gameObject.SetActive(true);
    }

    public void HideTimeIndicator()
    {
        timeIndicator.enabled = false;
    }

    public void ShowTimeIndicator()
    {
        timeIndicator.enabled = true;
    }

    public void ResetTimeIndicator()
    {
        UpdateTimeIndicator(1f);
    }

    public void UpdateTimeIndicator(float percentage)
    {
        timeIndicator.fillAmount = percentage;
    }

    public void ShowMenu()
    {
        MenuController.Show();
    }

    public void HideMenu()
    {
        MenuController.Hide();
    }
}
