using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAction : MonoBehaviour
{
    [SerializeField]
    private GameTileManager _gameTileManager;

    public Action Action;
    public GameAction(Action action)
    {
        Action = action;
    }

    private void Awake()
    {
        var gtm = GameObject.Find("TileManager").GetComponent<GameTileManager>();
        if (gtm == null)
        {
            Debug.Log("GTM is NULL");
        }
        else
        {
            _gameTileManager = gtm;
        }
    }
    void OnMouseDown()
    {
        Debug.Log("Do Action");
        if (Action.ActionType == ActionType.Explore)
        {
            //Check for succes or fail

            foreach (var tile in _gameTileManager.AllTilesInGame)
            {

                if (tile.Position == (Vector2)this.transform.parent.position)
                {
                    _gameTileManager.CreateGameTile(tile, _gameTileManager.AllFogTilesForGame[0]);
                    Debug.Log("Found it!");
                    Destroy(this.gameObject.transform.parent.gameObject);
                }
            }

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
