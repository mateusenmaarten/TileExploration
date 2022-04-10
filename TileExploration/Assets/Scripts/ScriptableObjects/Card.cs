using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : BaseScriptableObject
{
    public string CardName;
    public string Description;
    public Sprite CardSprite;
    public Action CardAction;
    public int Stars;
}
