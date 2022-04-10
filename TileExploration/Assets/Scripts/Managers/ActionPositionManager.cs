using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPositionManager : MonoBehaviour
{
    public Vector2 GetPositionOnTile(ActionPosition ap, Vector2 pos)
    {
        switch (ap)
        {
            case ActionPosition.TopLeft:
                return new Vector2(pos.x -0.9f, pos.y + 0.9f);
                break;
            case ActionPosition.TopCenter:
                return new Vector2(pos.x, pos.y + 0.9f);
                break;
            case ActionPosition.TopRight:
                return new Vector2(pos.x + 0.9f, pos.y + 0.9f);
                break;
            case ActionPosition.MiddleLeft:
                return new Vector2(pos.x -0.9f, pos.y);
                break;
            case ActionPosition.MiddleCenter:
                return new Vector2(pos.x, pos.y);
                break;
            case ActionPosition.MiddleRight:
                return new Vector2(pos.x + 0.9f, pos.y);
                break;
            case ActionPosition.BottomLeft:
                return new Vector2(pos.x -0.9f,pos.y -0.9f);
                break;
            case ActionPosition.BottomCenter:
                return new Vector2(pos.x, pos.y-0.9f);
                break;
            case ActionPosition.BottomRight:
                return new Vector2(pos.x + 0.9f,pos.y -0.9f);
                break;
            default:
                return new Vector2(pos.x,pos.y);
        }
    }
}
