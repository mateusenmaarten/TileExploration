using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAction : MonoBehaviour
{
    public Action Action;
    public GameAction(Action action)
    {
        Action = action;
    }

    private void Awake()
    {

    }
    void OnMouseDown()
    {
        Debug.Log("Do Action");
        if (Action.ActionType == ActionType.Explore)
        {
            //Check for succes or fail
            
            //foreach (var tile in _gameTileManager.AllTilesInGame)
            //{
                
            //    if (tile.Position == (Vector2)this.transform.parent.position)
            //    {
            //        Instantiate(_gameTile, new Vector3(tile.Position.x, tile.Position.y, 0), Quaternion.identity);
            //        //_gameTile.Tile = tile;
            //        Debug.Log("Found it!");
            //        Destroy(this.gameObject);
            //    }
            //}
            
        }
        //Do Action 
    }

    private void OnMouseOver()
    {
        Debug.Log("Showing Tooltip");
        //Show Tooltip
    }

    private void OnMouseExit()
    {
        Debug.Log("Tooltip No longer visible");
        //Destroy Tooltip
    }
}
