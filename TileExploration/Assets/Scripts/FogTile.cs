using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FogTile", menuName = "FogTile")]
public class FogTile : Tile
{
    public FogTile(Sprite fogsprite, List<Action> actions, Vector2 position) : base(fogsprite, actions, position)
    {

    }
}
