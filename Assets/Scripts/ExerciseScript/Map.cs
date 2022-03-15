using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    [System.Serializable]
    public struct Size
    {
        public uint widht;
        public uint height;
    }

    private WangTile[,] _map;
    private uint _widht, _height;

    public Map(Size size) : this(size.widht, size.height) { }

    public Map(uint width, uint height)
    {
        _widht = width;
        _height = height;

        _map = new WangTile[height, width];

        GenerateMap();
    }

    public void GenerateMap()
    {
        for (uint row = 0; row < _height; row++)
        {
            for (uint col = 0; col < _widht; col++)
            {
                //TODO : create generator
                var val = Random.Range(1, 16);
                _map[row, col] = new WangTile((uint)val);
            }
        }
    }

    public WangTile GetTile(uint row, uint col)
    {
        return _map[row, col];
    }
}