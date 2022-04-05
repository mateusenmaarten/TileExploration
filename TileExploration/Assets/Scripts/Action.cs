using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Action", menuName = "Action")]
public class Action : BaseScriptableObject
{
    public Sprite ActionIcon;
    public ActionType ActionType;
    public ActionPosition Position;
    //public ActionResult Result;
}
