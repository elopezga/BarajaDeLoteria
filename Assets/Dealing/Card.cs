using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Card
{
    [SerializeField] private string name;
    [SerializeField] private Image art;

    public string Name 
    { 
        get { return name; }
    }
}
