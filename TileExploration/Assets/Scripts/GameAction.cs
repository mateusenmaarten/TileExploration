using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAction : MonoBehaviour
{
    [SerializeField]
    private GameTileManager _gameTileManager;
    [SerializeField]
    private ActionManager _actionManager;

    public Action Action;
    private GameObject _tooltip;
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
        var am = GameObject.Find("ActionManager").GetComponent<ActionManager>();
        if (am == null)
        {
            Debug.Log("AM is NULL");
        }
        else
        {
            _actionManager = am;
        }
    }
    void OnMouseDown()
    {
        Debug.Log("Do Action");
        if (Action.ActionType == ActionType.Explore)
        {
            //Check for succes or fail
            foreach (var tile in _gameTileManager.AllTilesInLevel)
            {
                if (tile.Position == (Vector2)(this.transform.parent.position))
                {
                    _gameTileManager.CreateGameTile(tile, _gameTileManager.AllFogTilesForLevel[0]);
                    Debug.Log("Found it!");
                    Destroy(this.gameObject.transform.parent.gameObject);
                }
            }
        }
        //Do Action 
    }

    private void OnMouseEnter()
    {
        _tooltip = Instantiate(_actionManager.TooltipPrefab,this.transform.parent.position, Quaternion.identity);
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
        Destroy(_tooltip);
    }
}
