using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WangTile
{
    private uint _value;

    public WangTile(uint value)
    {
        if (value <= 0 || value >= 16)
        {
            throw new System.Exception("I valori della tile non possono essere inferiori a 0 o superiori a 15");
        }
        _value = value;
    }

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


}