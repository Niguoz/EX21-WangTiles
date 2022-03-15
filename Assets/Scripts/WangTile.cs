using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WangTile
{
    private int _value;
    public WangTile(int value)
    {
        if (value <= 0 || value >= 16)
        {
            throw new System.Exception("I valori della tile non possono essere inferiori a 0 o superiori a 15");
        }
        _value = value;
    }

    public int Value => _value;
}