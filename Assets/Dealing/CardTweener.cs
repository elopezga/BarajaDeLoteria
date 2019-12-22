using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardTweener : MonoBehaviour
{
    [SerializeField] private RectTransform cardPile;
    [SerializeField] private RectTransform discardPile;
    [SerializeField] private RectTransform drawnCardPile;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetToCardPile();
    }

    public void ResetToCardPile()
    {
        rectTransform.localPosition = cardPile.localPosition + Vector3.up * rectTransform.rect.height / 2f;
    }

    public void TweenDrawCard()
    {
        rectTransform.DOAnchorPos3D(drawnCardPile.localPosition, 0.5f, false);
        //rectTransform.localPosition = drawnCardPile.localPosition;
    }

    public void TweenDiscardCard(Action onComplete)
    {
        TweenCallback callback = () => {
            onComplete?.Invoke();
        };

        Sequence sequence = DOTween.Sequence();

        Vector3 targetPosition = discardPile.localPosition + Vector3.down * rectTransform.rect.height / 2f;
        sequence.Append(rectTransform.DOAnchorPos3D(targetPosition, 0.5f, false))
            .AppendInterval(0.2f)
            .OnComplete(callback);
        //rectTransform.localPosition = discardPile.localPosition + Vector3.down * rectTransform.rect.height / 2f;
    }
}
