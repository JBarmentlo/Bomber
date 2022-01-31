using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoomBoomTile : MonoBehaviour
{
    public  float           fuseTime    = 2.0f;
    public  PrefabTile      explosionTile;
    private Tilemap         tilemap;

    void Start()
    {
        tilemap = GetComponentInParent<Tilemap>();
        // Debug.Log("Getting tile");
        // tilemap.ClearAllTiles();
    }

    void Update()
    {
        fuseTime -= Time.deltaTime;
        if (fuseTime <= 0f){
            Debug.Log("EXPLODE");
            Explode(transform.position);
        }
    }
    void OnDestroy()
    {
        Debug.Log("Destroy");
    }
    public void Explode(Vector2 worldPos, int boomDist = 0)
    {
        Vector3Int  originCell  = tilemap.WorldToCell(worldPos);
        ExplodeCell(originCell);
    }

    private bool ExplodeCell(Vector3Int cell)
    {
        // Tile tile = tilemap.GetTile<Tile>(cell);
        // if (tile == wallTile)
        // {
        //     return true;
        // }
        // if (tile == destructibleTile)
        // {
        //     tilemap.SetTile(cell, null);
        //     return true;
        // }
        tilemap.SetTile(cell, explosionTile);
        // Vector3 centerPos = tilemap.GetCellCenterWorld(cell);
        // Instantiate(explosionPrefab, centerPos, Quaternion.identity);
        return true;
    }
}
