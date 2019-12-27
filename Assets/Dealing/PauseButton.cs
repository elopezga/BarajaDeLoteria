using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Sprite pauseImage;
    [SerializeField] private Sprite playImage;
    [SerializeField] private Image image;
    [SerializeField] private Button button;

    private bool isShowingPauseImage;

    private void Start()
    {
        isShowingPauseImage = true;
        image.sprite = pauseImage;
    }

    private void OnEnable()
    {
        button.onClick.AddListener(HandleOnClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(HandleOnClick);
    }

    public void AddListener(UnityAction callback)
    {
        button.onClick.AddListener(callback);
    }

    public void RemoveListener(UnityAction callback)
    {
        button.onClick.RemoveListener(callback);
    }

    private void HandleOnClick()
    {
        if (isShowingPauseImage)
        {
            image.sprite = playImage;
        }
        else
        {
            image.sprite = pauseImage;
        }

        isShowingPauseImage = !isShowingPauseImage;
    }

    public void SetAsPause()
    {
        image.sprite = pauseImage;
    }

    public void SetAsPlay()
    {
        image.sprite = playImage;
    }

    public void Reset()
    {
        isShowingPauseImage = true;
        image.sprite = pauseImage;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
