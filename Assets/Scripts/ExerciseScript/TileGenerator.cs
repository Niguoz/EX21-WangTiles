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
    public AbstractWangTile tilePrefab;
    void Start()
    {
       Generate();
    }

    public void Generate()
    {
        _map = new Map(size.widht, size.height, Map.Type.Linear);
       // _map.GenerateMap();

        for (int row = 0; row < size.height; row++)
        {
            for (int col = 0; col < size.widht; col++)
            {
                var val = _map.GetTile((uint)row, (uint)col);

                var wt = Instantiate(tilePrefab);
                wt.Init(val);
                wt.transform.position = new Vector3(col, row, 0);
            }
        }
    }
}