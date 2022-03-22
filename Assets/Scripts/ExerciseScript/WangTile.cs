using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WangTile
{
    private uint _value;
    uint _row, _col = 0;
    public WangTile(uint value, uint row , uint col )
    {
        _row = row;
        _col = col;
        if (value < 0 || value >= 16)
        {
            throw new System.Exception("I valori della tile non possono essere inferiori a 0 o superiori a 15");
        }
        _value = value;
    }

    public uint Row => _row;
    public uint Col => _col;

    public uint Value => _value;

    public bool North => (_value & 1) != 0;
    public bool South => (_value & 4) != 0;
    public bool East => (_value & 2) != 0;
    public bool West => (_value & 8) != 0;

    ///Non proprio il massimo...
    /*public bool NorthEast => North;
    public bool SouthEast => East;
    public bool SouthWest => South;
    public bool NorthWest => West;*/

    public void OpenDoor(uint direction)
    {
        if (direction > 8) throw new System.Exception("I valori possibili per le tile vanno da 0 a 8!");
        if (direction != 0 && direction != 1 && direction != 2 && direction != 4 && direction != 8)
        {
            throw new System.Exception("Puoi aprire solo una porta");
        }

        if((_value & direction) == 0) 
        {
            _value += direction;
        }
        else
        {
            Debug.Log("La porta è già esistente");
        }
    }

    public void OpenDoors(uint directions)
    {
        OpenDoor(directions & 1);
        OpenDoor(directions & 2);
        OpenDoor(directions & 4);
        OpenDoor(directions & 8);
    }

}