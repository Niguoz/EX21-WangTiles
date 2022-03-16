using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Wang : MonoBehaviour
{
    protected WangTile _data;
    public SpriteRenderer rend;
    public void Init(WangTile data)
    {
        var operation = Addressables.LoadAssetAsync<Sprite>(data.Value);
        operation.Completed += OnLoadComplete;
    }

    private void OnLoadComplete(AsyncOperationHandle<Sprite> handle)
    {
        if(handle.Status != AsyncOperationStatus.Succeeded) return;
        rend.sprite = handle.Result;
    }
}
