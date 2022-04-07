using System.Collections.Generic;
using UnityEngine;

public class GameTileManager : MonoBehaviour
{
    [SerializeField]
    private Vector2 _startingTilePosition = new Vector2(0, 0);
    public ObjectFactory objectFactory;
    public MapCreator mapCreator;

    public Tile StartingTile;
    public FogTile StartingFogTile;

    public List<Tile> AllTilesInLevel = new List<Tile>();
    public List<FogTile> AllFogTilesForLevel = new List<FogTile>();

    public List<Vector2> OpenTilePositions = new List<Vector2>();
    public List<Vector2> OpenFogTilePositions = new List<Vector2>();

    [SerializeField]
    private int _tileOffset = 3;

    // Start is called before the first frame update
    void Start()
    {
        mapCreator.CreateTilesForLevel(1);

        FillOpenTilePositions();
        FillOpenFogTilePositions();

        foreach (var tile in mapCreator.TilesOnPosition.Values)
        {
            AllTilesInLevel.Add(tile);
        }

        AllFogTilesForLevel.Add(StartingFogTile); 

        CreateStartingGameTile();
    }

    public void CreateGameTile(Tile tile, FogTile fogtile)
    {
        var gameTile = objectFactory.CreateGameTile(tile, fogtile);
        foreach (var item in mapCreator.TilesOnPosition)
        {
            if (item.Value.name == tile.name)
            {
                gameTile.transform.position = tile.Position;
                Debug.Log($"Created tile {tile.name} at {tile.Position}");
            }
        }
        
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

        var North = new Vector2(gameTile.Tile.Position.x, gameTile.Tile.Position.y + _tileOffset);
        var East = new Vector2(gameTile.Tile.Position.x + _tileOffset, gameTile.Tile.Position.y);
        var South = new Vector2(gameTile.Tile.Position.x, gameTile.Tile.Position.y - _tileOffset);
        var West = new Vector2(gameTile.Tile.Position.x - _tileOffset, gameTile.Tile.Position.y);

        if (IsPositionOpen(North))
        {
            Debug.Log($"GameTile: {gameTile.Tile.Position}, Added North: {North}");
            FogTilePositions.Add(North);
        }
        if (IsPositionOpen(East))
        {
            Debug.Log($"Added East: {East}");
            FogTilePositions.Add(East);
        }
        if (IsPositionOpen(South))
        {
            Debug.Log($"Added South: {South}");
            FogTilePositions.Add(South);
        }
        if (IsPositionOpen(West))
        {
            Debug.Log($"Added West: {West}");
            FogTilePositions.Add(West);
        }
        return FogTilePositions;
    }
    private void FillOpenTilePositions()
    {
        OpenTilePositions = new List<Vector2>();
        foreach (var item in mapCreator.TilesOnPosition)
        {
            OpenTilePositions.Add(item.Key);
        }
    }
    private void FillOpenFogTilePositions()
    {
        foreach (var key in mapCreator.TilesOnPosition.Keys)
        {
            OpenFogTilePositions.Add(key);
        }
        var startpos = OpenFogTilePositions.Find(pos => pos.x == 0 && pos.y == 0);
        OpenFogTilePositions.Remove(startpos);
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
            if (OpenFogTilePositions.Contains(fogPos))
            {
                var gameFogTile = objectFactory.CreateGameFogTile(gameTile.FogTile);
                gameFogTile.Tile.Position = fogPos;
                gameFogTile.transform.position = fogPos;
                OpenFogTilePositions.Remove(fogPos);
            }
        }
    }
}
