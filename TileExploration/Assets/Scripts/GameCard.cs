using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCard : MonoBehaviour
{
    public GameAction GameActionPrefab;
    public GameObject SuccessPrefab;

    public Text CardName;
    public Text CardDescription;
    public Image CardSprite;
    public GameAction CardAction;
    public List<GameObject> Stars;

    [SerializeField]
    private Card _card;
    public GameCard(Card card)
    {
        _card = card;
    }

    public Card Card
    {
        get { return _card; }
        set { _card = value; }
    }

    private void Start()
    {
        CardName.text = _card.CardName;
        CardDescription.text = _card.Description;
        CardSprite.sprite = _card.CardSprite;
        CardAction = Instantiate(GameActionPrefab, this.transform);
        for (int i = 0; i < _card.Stars; i++)
        {
            var star = Instantiate(SuccessPrefab, this.transform);
            Stars.Add(star);
        }
        
}
}
