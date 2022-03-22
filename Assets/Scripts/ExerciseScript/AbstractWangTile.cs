using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWangTile : MonoBehaviour, IWangTile
{
    protected WangTile _data;
    
    public virtual void Init(WangTile data)
    {
        _data = data;
    }

    public bool North => _data.North;
    public bool South => _data.South;
    public bool East => _data.East;
    public bool West => _data.West;
}