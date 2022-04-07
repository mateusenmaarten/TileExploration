using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    private List<Vector2> _positions = new List<Vector2>(); 
    public List<Tile> _tiles = new List<Tile>();

    public Dictionary<Vector2, Tile> TilesOnPosition = new Dictionary<Vector2, Tile>();

    void Awake()
    {
        _positions.Add(new Vector2(-6, 3));
        _positions.Add(new Vector2(-3, 3));
        _positions.Add(new Vector2(0, 3));
        _positions.Add(new Vector2(3, 3));
        _positions.Add(new Vector2(6, 3));
        _positions.Add(new Vector2(-6, 0));
        _positions.Add(new Vector2(-3, 0));
        _positions.Add(new Vector2(0, 0));
        _positions.Add(new Vector2(3, 0));
        _positions.Add(new Vector2(6, 0));
        _positions.Add(new Vector2(-6, -3));
        _positions.Add(new Vector2(-3, -3));
        _positions.Add(new Vector2(0, -3));
        _positions.Add(new Vector2(3, -3));
        _positions.Add(new Vector2(6, -3));
        
    }

    public void CreateTilesForLevel(int level)
    {
        switch (level)
        {
            case 1: CreateLevelOneTiles();
                break;
            default:
                CreateLevelOneTiles();
                break;
        }
    }

    private void CreateLevelOneTiles()
    {
        TilesOnPosition = new Dictionary<Vector2, Tile>();

        for (int i = 0; i != Math.Min(_positions.Count, _tiles.Count); i++) 
        {
            TilesOnPosition.Add(_positions[i], _tiles[i]);
            _tiles[i].Position = new Vector2(_positions[i].x, _positions[i].y);
        }
    }
}
