using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTile : MonoBehaviour
{
    public Tile Tile;
    public FogTile FogTile;
    public List<GameAction> GameActions;

    public GameTile(Tile tile, FogTile fogTile)
    {
        Tile = tile;
        FogTile = fogTile;
    }
    public GameTile(Tile tile)
    {
        Tile = tile;
    }
}
