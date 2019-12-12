using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Deck", menuName = "Decks/Deck", order = 1)]
public class DeckScriptableObject : ScriptableObject
{
    [SerializeField] private List<Card> cards;

    public Deck CreateDeck()
    {
        return new Deck(cards);
    }

    public Stack<Card> CreateDeckRandom()
    {
        throw new System.NotImplementedException();
    }
}
