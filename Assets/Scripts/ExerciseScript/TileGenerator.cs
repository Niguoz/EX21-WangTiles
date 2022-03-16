using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class TileGenerator : MonoBehaviour
{
    public Map.Size size;
    public float tileSize = 32;
    private Map _map;

    void Start()
    {
        Generate();
    }

    public void Generate()
    {
        _map = new Map(size.widht, size.height);
        _map.GenerateMap();

        for (int row = 0; row < size.height; row++)
        {
            var output = "";
            for (int col = 0; col < size.widht; col++)
            {
                var val = _map.GetTile((uint)row, (uint)col).Value;
                output += val + " - ";

                var go = new GameObject("Tile " + row + " " + col);
                var sr = go.AddComponent<SpriteRenderer>();
                // var sprite = Resources.Load<Sprite>(val.ToString());
                var operation = Addressables.LoadAssetAsync<Sprite>(val.ToString());
                operation.Completed += OnLoadComplete;
                // sr.sprite = sprite;
                // go.transform.position = new Vector3(col, row, 0);
            }
        }
    }

    protected void OnLoadComplete(AsyncOperationHandle<Sprite> handle)
    {

    }
}