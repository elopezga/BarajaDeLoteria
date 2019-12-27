using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class MenuController : MonoBehaviour
{
    [SerializeField] private RectTransform menuEnterTarget;
    [SerializeField] private RectTransform menuExitTarget;
    [SerializeField] private Button startButton;

    private RectTransform rectTransform;

    private void OnEnable()
    {
        startButton.onClick.AddListener(HandleOnStartClicked);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(HandleOnStartClicked);
    }

    // Start is called before the first frame update
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void Show()
    {
        rectTransform.DOAnchorPos3D(menuEnterTarget.localPosition, 0.5f, false);
    }

    public void Hide()
    {
        Vector3 targetPosition = menuExitTarget.localPosition + Vector3.left * rectTransform.rect.width / 2f;
        rectTransform.DOAnchorPos3D(targetPosition, 0.5f, false);
        //rectTransform.DOAnchorPos3D(menuExitTarget.localPosition, 0.5f, false);
    }

    public void AddListenerOnStartClick(UnityAction callback)
    {
        startButton.onClick.AddListener(callback);
    }

    public void RemoveListenerOnStartClick(UnityAction callback)
    {
        startButton.onClick.RemoveListener(callback);
    }

    private void HandleOnStartClicked()
    {
        Hide();
    }
}
