using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Tile", menuName ="Tile")]
public class Tile : BaseScriptableObject
{
    public Tile(Sprite tileSprite, List<Action> tileActions, Vector2 position)
    {

    }
    public Sprite TileSprite;
    public List<Action> TileActions;
    public Vector2 Position;
}
