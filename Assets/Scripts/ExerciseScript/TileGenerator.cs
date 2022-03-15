using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                var spriteSheet = Resources.LoadAll("Wang");
                var sprite = (Sprite)spriteSheet[val + 1];
                sr.sprite = sprite;
                go.transform.position = new Vector3(col, row, 0);
            }
            Debug.Log(output);
        }
    }
}
