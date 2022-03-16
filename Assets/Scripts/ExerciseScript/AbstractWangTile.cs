using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWangTile : MonoBehaviour, IWangTile
{
    public abstract void Init(WangTile data);
    
}