using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    [System.Serializable]
    public struct Size
    {
        public int widht;
        public int height;
    }

    private WangTile[,] _map;
    private uint _widht, _height;
    public Map(uint width, uint height)
    {
        _widht = width;
        _height = height;

        _map = new WangTile[width, height];

        GenerateMap();
    }

    public void GenerateMap()
    {
        for (uint row = 0; row < _widht; row++)
        {
            for (uint col = 0; col < _height; col++)
            {
                var val = Random.Range(1, 16);
                _map[row, col] = new WangTile((uint) val);
            }
        }
    }
}