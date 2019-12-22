using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private Text displayName;

    private CardTweener tweener;

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<CardTweener>();
        tweener.ResetToCardPile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleCardDraw(Card card)
    {
        UpdateView(card);
        tweener.TweenDrawCard();
    }

    public void UpdateView(Card card)
    {
        displayName.text = card.Name;
        tweener.TweenDrawCard();
    }

    public void DiscardCard(Action onComplete)
    {
        Action callback = () => {
            tweener.ResetToCardPile();
            onComplete?.Invoke();
        };
        tweener.TweenDiscardCard(callback);
    }
}
