using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private Text displayName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateView(Card card)
    {
        displayName.text = card.Name;
    }
}
