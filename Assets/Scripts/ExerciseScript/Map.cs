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

    public enum Type
    {
        Random,
        Linear,
        Checker,
        Perfect
    }

    private WangTile[,] _map;
    private uint _widht, _height;

    public Map(Size size) : this(size.widht, size.height) { }
    public Map(Size size, Type type = Type.Random) : this(size.widht, size.height, type) { }
    public Map(uint width, uint height, Type type = Type.Random)
    {
        _widht = width;
        _height = height;

        _map = new WangTile[height, width];
        switch (type)
        {
            case Type.Random:
                GenerateRandomMap();
                break;
            case Type.Linear:
                GenerateLinear();
                break;
            default:
                break;

        }

    }

    public void GenerateRandomMap(Type mapType = Type.Random)
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

    public void GenerateLinear()
    {
        for (uint row = 0; row < _height; row++)
        {
            for (uint col = 0; col < _widht; col++)
            {
                uint val = 0;
                if (row == 0 & col == 0)
                {
                    val = (uint)Random.Range(1, 4);
                }
                else
                {
                    if (col != 0)
                    {
                        if (_map[row, col - 1].East) val += 8;
                    }
                    if (col != _widht - 1) val += (uint)(Random.Range(0, 2) < 1 ? 0 : 2);
                }
                _map[row, col] = new WangTile((uint)val);
            }
        }
    }
}