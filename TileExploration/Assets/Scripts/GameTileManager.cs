using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTileManager : MonoBehaviour
{

    //SpecialEnemy enemy = Object.Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity).GetComponent<SpecialEnemy>();

    //enemy.Initialize("Darth Vader", 9000, "lightsaber", true);

    public List<Tile> AllTilesInGame;
    public List<Vector2> OpenTilePositions;
    private List<Vector2> _fogTilePositions;
    private GameFogTile _fogTilePrefab;
    private SpriteRenderer _sprite;

    public List<GameAction> Actions;
    public Tile Tile;                            //Instantiate GameTile and give it the correct tile + Instantiate Fogtiles for that GameTile and give FogTile
    public Tile FogTile;
    [SerializeField]
    private int _tileOffset = 3;

    private void Awake()
    {
        _fogTilePositions = new List<Vector2>();

    }
    // Start is called before the first frame update
    void Start()
    {
        FillOpenTilePositions();

        var origin = new Vector2(0, 0);
        OpenTilePositions.Remove(origin);

        Vector2 currentTilePosition = new Vector2(transform.position.x, transform.position.y);
        var tileToRemoveFromOpenTiles = OpenTilePositions.Find(pos => pos.x == currentTilePosition.x && pos.y == currentTilePosition.y);
        if (tileToRemoveFromOpenTiles != null)
        {
            OpenTilePositions.Remove(tileToRemoveFromOpenTiles);
        }

        _sprite = GetComponent<SpriteRenderer>();

        foreach (var fogPos in GetFogTilePositions(this.transform.position, Tile))
        {
            if (IsPositionOpen(fogPos))
            {
                var fogTile = Instantiate(_fogTilePrefab, new Vector3(fogPos.x, fogPos.y, 0), Quaternion.identity);
                OpenTilePositions.Remove(fogPos);
            }
        }
    }

    public void SetTileSprite(Tile tile)
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



    private bool IsPositionOpen(Vector2 position)
    {
        var pos = OpenTilePositions.Find(pos => pos.x == position.x && pos.y == position.y);
        if (pos != null)
        {
            OpenTilePositions.Remove(pos);
            return true;
        }
        else
        {
            return false;
        }

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
    private void FillOpenTilePositions()
    {
        OpenTilePositions = new List<Vector2>()
        {
            new Vector2(-6,3)
            ,new Vector2(-3,3)
            ,new Vector2(0,3)
            ,new Vector2(3,3)
            ,new Vector2(6,3)
            ,new Vector2(-6,0)
            ,new Vector2(-3,0)
            ,new Vector2(0,0)
            ,new Vector2(3,0)
            ,new Vector2(6,0)
            ,new Vector2(-6,-3)
            ,new Vector2(-3,-3)
            ,new Vector2(0,-3)
            ,new Vector2(3,-3)
            ,new Vector2(6,-3)
        };
    }
}
