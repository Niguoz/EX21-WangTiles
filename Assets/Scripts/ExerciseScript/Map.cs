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
            case Type.Perfect:
                GeneratePerfect();
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
                _map[row, col] = new WangTile((uint)val, row, col);
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

                    if (row != 0)
                    {
                        if (_map[row - 1, col].North) val += 4;
                    }
                    if (row != _height - 1) val += (uint)(Random.Range(0, 2) < 1 ? 0 : 1);
                }
                _map[row, col] = new WangTile((uint)val, row, col);
            }
        }
    }

    public void GeneratePerfect()
    {
        //Genero la griglia vuota
        for (uint row = 0; row < _height; row++)
        {
            for (uint col = 0; col < _widht; col++)
            {
                _map[row, col] = new WangTile(0, row, col);
            }
        }

        // Creo la lista di elementi visitati
        var visited = new List<WangTile>();

        // Prendo una tile a caso e la aggiungo alla lista degli elementi visitati
        var tile = _map[(uint)Random.Range(0, _height), (uint)Random.Range(0, _widht)];
        visited.Add(tile);

        while (visited.Count > 0)
        {
            // Randomizzazione
            var t = visited[Random.Range(0, visited.Count)];

            var list = new List<WangTile>();
            var listDirection = new List<uint>();

            // Controllo a nord
            if (
                (!t.North) &&
                (t.Row < _height - 1) &&
                (_map[t.Row + 1, t.Col].Value == 0)
                )
            {
                list.Add(_map[t.Row + 1, t.Col]);
                listDirection.Add(1);
            }

            // Controllo a sud
            if (
                (!t.South) &&
                (t.Row != 0) &&
                (_map[t.Row - 1, t.Col].Value == 0)
                )
            {
                list.Add(_map[t.Row - 1, t.Col]);
                listDirection.Add(4);
            }

            //Controllo a est
            if (
                (!t.East) &&
                (t.Col < _widht - 1) &&
                (_map[t.Row, t.Col + 1].Value == 0)
                )
            {
                list.Add(_map[t.Row, t.Col + 1]);
                listDirection.Add(2);
            }

            //Controllo a ovest
            if (
                (!t.West) &&
                (t.Col != 0) &&
                (_map[t.Row, t.Col - 1].Value == 0)
                )
            {
                list.Add(_map[t.Row, t.Col - 1]);
                listDirection.Add(8);
            }

            if (list.Count == 0)
            {
                visited.Remove(t);
            }
            else
            {
                var index = Random.Range(0, list.Count);
                var result = list[index];
                t.OpenDoor(listDirection[index]);
                result.OpenDoor(GetCorrespondingDoor(listDirection[index]));
                visited.Add(result);
            }
        }
    }

    protected uint GetCorrespondingDoor(uint direction)
    {
        switch (direction)
        {
            case 1:
                return 4;
            case 4:
                return 1;
            case 2:
                return 8;
            case 8:
                return 2;
            default:
                throw new System.Exception("Valore non valido");
        }
    }

}