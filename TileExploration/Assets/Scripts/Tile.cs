using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Tile", menuName ="Tile")]
public class Tile : BaseScriptableObject
{
    public Sprite TileSprite;
    public List<Action> TileActions;
    public Vector2 Position;
    public bool FogNorth;
    public bool FogEast;
    public bool FogSouth;
    public bool FogWest;
}
