using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTile : MonoBehaviour
{
    private List<Vector2> _fogTilePositions;
    private GameAction _gameActionPrefab;
    private GameFogTile _fogTilePrefab;
    private ActionPositionManager _apm;
    private GameTileManager _tm;
    private SpriteRenderer _sprite;

    public List<GameAction> Actions;
    public Tile Tile;
    public Tile FogTile;
    [SerializeField]
    private int _tileOffset = 3;

    private void Awake()
    {
        _fogTilePositions = new List<Vector2>();

        var apm = GameObject.Find("ActionPositionManager").GetComponent<ActionPositionManager>();
        if (apm != null)
        {
            _apm = apm;
        }
        else
        {
            Debug.Log("ActionPositionManager is NULL");
        }

        var tm = GameObject.Find("TileManager").GetComponent<GameTileManager>();
        if (tm != null)
        {
            _tm = tm;
        }
        else
        {
            Debug.Log("TileManager is NULL");
        }

        var gameActionPrefab = GameObject.Find("GameAction").GetComponent<GameAction>();
        if (apm != null)
        {
            _gameActionPrefab = gameActionPrefab;
        }
        else
        {
            Debug.Log("GameActionPrefab is NULL");
        }

        var fogTilePrefab = GameObject.Find("GameFogTile").GetComponent<GameFogTile>();
        if (tm != null)
        {
            _fogTilePrefab = fogTilePrefab;
        }
        else
        {
            Debug.Log("GameFogTile is NULL");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (this.transform.position.x != 11)
        {
            Vector2 currentTilePosition = new Vector2(transform.position.x, transform.position.y);
            var tileToRemoveFromOpenTiles = _tm.OpenTilePositions.Find(pos => pos.x == currentTilePosition.x && pos.y == currentTilePosition.y);
            if (tileToRemoveFromOpenTiles != null)
            {
                _tm.OpenTilePositions.Remove(tileToRemoveFromOpenTiles);
            }

            Actions = new List<GameAction>();
            _sprite = GetComponent<SpriteRenderer>();

            if (this.Tile != null)
            {
                CreateTileActions(_gameActionPrefab, Tile.TileActions, this.transform);
            }

            foreach (var fogPos in GetFogTilePositions(this.transform.position, Tile))
            {
                if (IsPositionOpen(fogPos))
                {
                    var fogTile = Instantiate(_fogTilePrefab, new Vector3(fogPos.x, fogPos.y, 0), Quaternion.identity);
                    _tm.OpenTilePositions.Remove(fogPos);
                }
            }

        }

    }

    public void SetSprite(Tile tile)
    {
        if (_sprite == null)
        {
            Debug.Log("Tile image is NULL");
        }
        else
        {
            _sprite.sprite = tile.TileSprite;
        }
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
            Actions.Add(ga);
        }
        actions = new List<Action>();
    }

    private bool IsPositionOpen(Vector2 position)
    {
        var pos = _tm.OpenTilePositions.Find(pos => pos.x == position.x && pos.y == position.y);
        if (pos != null)
        {
            return true;
        }
        return false;
    }

    private List<Vector2> GetFogTilePositions(Vector2 tileposition, Tile tile)
    {
        _fogTilePositions = new List<Vector2>();
        if (tile.FogNorth)
        {
            var North = new Vector2(tileposition.x, tileposition.y + _tileOffset);
            _fogTilePositions.Add(North);
        }
        if (tile.FogEast)
        {
            var East = new Vector2(tileposition.x + _tileOffset, tileposition.y);
            _fogTilePositions.Add(East);
        }
        if (tile.FogSouth)
        {
            var South = new Vector2(tileposition.x, tileposition.y - _tileOffset);
            _fogTilePositions.Add(South);
        }
        if (tile.FogWest)
        {
            var West = new Vector2(tileposition.x - _tileOffset, tileposition.y);
            _fogTilePositions.Add(West);
        }

        return _fogTilePositions;
    }
}
