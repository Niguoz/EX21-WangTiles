using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Wang : AbstractWangTile
{
    protected WangTile _data;
    public SpriteRenderer rend;
    public override void Init(WangTile data)
    {
        var operation = Addressables.LoadAssetAsync<Sprite>(data.Value.ToString());
        operation.Completed += OnLoadComplete;
    }

    private void OnLoadComplete(AsyncOperationHandle<Sprite> handle)
    {
        if(handle.Status != AsyncOperationStatus.Succeeded) return;
        rend.sprite = handle.Result;
    }
}
