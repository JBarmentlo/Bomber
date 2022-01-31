using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawnerTile : MonoBehaviour
{
    private Tilemap     tilemap;
    public  PrefabTile  bombPrefabTile;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("BOMBERSCVRIP");
            Vector3     worldPos        = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int  cell            = tilemap.WorldToCell(worldPos);
            Vector3     cellCenterPos   = tilemap.GetCellCenterWorld(cell);

            tilemap.SetTile(cell, bombPrefabTile);
            // Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
        }
    }
}

