using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTileManager : MonoBehaviour
{
    public List<Vector2> OpenTilePositions;
    void Start()
    {
        FillOpenTilePositions();
    }
    private void FillOpenTilePositions()
    {
        OpenTilePositions = new List<Vector2>()
        {
            new Vector2(-6,3)
            ,new Vector2(-3,3)
            ,new Vector2(0,3)
            ,new Vector2(3,3)
            ,new Vector2(6,3)
            ,new Vector2(-6,0)
            ,new Vector2(-3,0)
            ,new Vector2(0,0)
            ,new Vector2(3,0)
            ,new Vector2(6,0)
            ,new Vector2(-6,-3)
            ,new Vector2(-3,-3)
            ,new Vector2(0,-3)
            ,new Vector2(3,-3)
            ,new Vector2(6,-3)
        };
    }
}
