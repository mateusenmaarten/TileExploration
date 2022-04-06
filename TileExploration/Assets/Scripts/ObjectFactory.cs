using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    [SerializeField]
    private GameTile _gameTilePrefab;
    [SerializeField]
    private GameTile _fogTilePrefab;
    [SerializeField]
    private GameAction _gameActionPrefab;
    [SerializeField]
    private ActionPositionManager _apm;

    public GameTile CreateGameTile(Tile tile, FogTile fogTile)
    {
        GameTile gameTile = Instantiate(_gameTilePrefab, new Vector2(), Quaternion.identity).GetComponent<GameTile>();
        gameTile.Tile = tile;
        gameTile.FogTile = fogTile;
        gameTile.GetComponent<SpriteRenderer>().sprite = tile.TileSprite;
        gameTile.GameActions = CreateGameActions(_gameActionPrefab, tile.TileActions, gameTile.transform);
        return gameTile;
    }
    public GameTile CreateGameFogTile(Tile tile)
    {
        GameFogTile gameFogTile = Instantiate(_fogTilePrefab, new Vector2(), Quaternion.identity).GetComponent<GameFogTile>();
        gameFogTile.Tile = tile;
        gameFogTile.FogTile = null;
        gameFogTile.GetComponent<SpriteRenderer>().sprite = tile.TileSprite;
        gameFogTile.GameActions = CreateGameActions(_gameActionPrefab, tile.TileActions, gameFogTile.transform);
        return gameFogTile;
    }
    private List<GameAction> CreateGameActions(GameAction gameAction, List<Action> actions, Transform parent)
    {
        List<GameAction> gameActions = new List<GameAction>();
        foreach (var tileAction in actions)
        {
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
                ga.transform.position = parent.transform.position;
            }
            ga.name = tileAction.name;
            gameActions.Add(ga);
        }
        return gameActions;
    }
}
