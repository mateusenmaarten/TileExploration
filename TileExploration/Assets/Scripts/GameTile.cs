using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTile : MonoBehaviour
{
    [SerializeField]
    private Tile _tile;
    [SerializeField]
    private FogTile _fogTile;
    [SerializeField]
    private List<GameAction> _gameActions;
    [SerializeField]
    private GameAction _gameActionPrefab;
    [SerializeField]
    private ActionPositionManager _apm;

    public GameTile(Tile tile, FogTile fogTile, GameAction gameActionPrefab, ActionPositionManager apm)
    {
        _apm = apm;
        _tile = tile;
        _fogTile = fogTile;
        _gameActionPrefab = gameActionPrefab;
    }
    public GameTile(Tile tile, GameAction gameActionPrefab, ActionPositionManager apm)
    {
        _apm = apm;
        _tile = tile;
        _gameActionPrefab = gameActionPrefab;
    }

    void Awake()
    {
        //Get Data to show (sprite) 
        GetComponent<SpriteRenderer>().sprite = _tile.TileSprite;

        CreateTileActions(_gameActionPrefab, _tile.TileActions, this.transform);
    }

    public void CreateTileActions(GameAction gameAction, List<Action> actions, Transform parent)
    {
        foreach (var tileAction in actions)
        {
            //Instantiate Action and add to list
            var ga = Instantiate(gameAction, parent);
            ga.Action = tileAction;
            var sprite = ga.GetComponent<SpriteRenderer>();
            sprite.sprite = tileAction.ActionIcon;
            if (ga.Action.name != "ExploreAction")
            {
                ga.transform.position = _apm.GetPositionOnTile(ga.Action.Position);
            }
            else
            {
                ga.transform.position = this.transform.position;
            }
            ga.name = tileAction.name;
            _gameActions.Add(ga);
        }
    }

}
