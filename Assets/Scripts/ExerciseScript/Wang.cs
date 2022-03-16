
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Wang : AbstractWangTile
{
    public SpriteRenderer rend;
    public override void Init(WangTile data)
    {
        base.Init(data);
        var operation = Addressables.LoadAssetAsync<Sprite>(data.Value.ToString());
        operation.Completed += OnLoadComplete;
    }

    private void OnLoadComplete(AsyncOperationHandle<Sprite> handle)
    {
        if(handle.Status != AsyncOperationStatus.Succeeded) return;
        rend.sprite = handle.Result;
    }

    
}
