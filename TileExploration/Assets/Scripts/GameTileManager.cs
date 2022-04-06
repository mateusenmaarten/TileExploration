using System.Collections.Generic;
using UnityEngine;

public class GameTileManager : MonoBehaviour
{
    [SerializeField]
    private Vector2 _startingTilePosition = new Vector2(0, 0);
    public ObjectFactory objectFactory;
    public Tile StartingTile;
    public FogTile StartingFogTile;

    public List<Tile> AllTilesInGame;
    public List<FogTile> AllFogTilesForGame;

    public List<Vector2> OpenTilePositions = new List<Vector2>();
    public List<Vector2> OpenFogTilePositions = new List<Vector2>();

    [SerializeField]
    private int _tileOffset = 3;

    // Start is called before the first frame update
    void Start()
    {
        FillOpenTilePositions();
        FillOpenFogTilePositions();

        CreateStartingGameTile();
    }

    public void CreateGameTile(Tile tile, FogTile fogtile)
    {
        var gameTile = objectFactory.CreateGameTile(tile, fogtile);
        gameTile.transform.position = tile.Position;
        OpenTilePositions.Remove(tile.Position);

        CreateGameFogTiles(gameTile);
    }
    private bool IsPositionOpen(Vector2 position)
    {
        var pos = OpenFogTilePositions.Find(pos => pos.x == position.x && pos.y == position.y);
        if (pos != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    private List<Vector2> GetFogTilePositions(GameTile gameTile)
    {
        var FogTilePositions = new List<Vector2>();
        if (gameTile.Tile.FogNorth)
        {
            var North = new Vector2(gameTile.Tile.Position.x, gameTile.Tile.Position.y + _tileOffset);
            FogTilePositions.Add(North);
        }
        if (gameTile.Tile.FogEast)
        {
            var East = new Vector2(gameTile.Tile.Position.x + _tileOffset, gameTile.Tile.Position.y);
            FogTilePositions.Add(East);
        }
        if (gameTile.Tile.FogSouth)
        {
            var South = new Vector2(gameTile.Tile.Position.x, gameTile.Tile.Position.y - _tileOffset);
            FogTilePositions.Add(South);
        }
        if (gameTile.Tile.FogWest)
        {
            var West = new Vector2(gameTile.Tile.Position.x - _tileOffset, gameTile.Tile.Position.y);
            FogTilePositions.Add(West);
        }
        return FogTilePositions;
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
            ,new Vector2(3,0)
            ,new Vector2(6,0)
            ,new Vector2(-6,-3)
            ,new Vector2(-3,-3)
            ,new Vector2(0,-3)
            ,new Vector2(3,-3)
            ,new Vector2(6,-3)
        };
    }
    private void FillOpenFogTilePositions()
    {
        OpenFogTilePositions = new List<Vector2>()
        {
            new Vector2(-6,3)
            ,new Vector2(-3,3)
            ,new Vector2(0,3)
            ,new Vector2(3,3)
            ,new Vector2(6,3)
            ,new Vector2(-6,0)
            ,new Vector2(-3,0)
            ,new Vector2(3,0)
            ,new Vector2(6,0)
            ,new Vector2(-6,-3)
            ,new Vector2(-3,-3)
            ,new Vector2(0,-3)
            ,new Vector2(3,-3)
            ,new Vector2(6,-3)
        };
    }
    private void CreateStartingGameTile()
    {
        var startingGameTile = objectFactory.CreateGameTile(StartingTile, StartingFogTile);
        startingGameTile.transform.position = _startingTilePosition;
        OpenTilePositions.Remove(_startingTilePosition);

        CreateGameFogTiles(startingGameTile);
    }
    private void CreateGameFogTiles(GameTile gameTile)
    {
        foreach (var fogPos in GetFogTilePositions(gameTile))
        {
            if (IsPositionOpen(fogPos))
            {
                var gameFogTile = objectFactory.CreateGameFogTile(gameTile.FogTile);
                gameFogTile.transform.position = fogPos;
                OpenFogTilePositions.Remove(fogPos);
            }
        }
    }
}
