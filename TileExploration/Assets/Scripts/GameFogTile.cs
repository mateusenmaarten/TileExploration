using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFogTile : GameTile
{
    [SerializeField]
    private Tile _tile;
    [SerializeField]
    private List<GameAction> _gameActions;
    [SerializeField]
    private GameAction _gameActionPrefab;
    [SerializeField]
    private ActionPositionManager _apm;

    public GameFogTile(Tile tile, GameAction gameActionPrefab, ActionPositionManager apm) : base(tile, gameActionPrefab, apm)
    {
        _tile = tile;
        _gameActionPrefab = gameActionPrefab;
    }

    private void Awake()
    {
        //Get Data to show (sprite) 
        GetComponent<SpriteRenderer>().sprite = _tile.TileSprite;

        //Instantiate GameActions
        foreach (var action in _tile.TileActions)
        {
            var gameAction = Instantiate(_gameActionPrefab, this.transform).GetComponent<GameAction>();
            gameAction.Action = action;
            gameAction.name = action.name;
            gameAction.GetComponent<SpriteRenderer>().sprite = action.ActionIcon;

            _gameActions.Add(gameAction);
        }
    }

}
