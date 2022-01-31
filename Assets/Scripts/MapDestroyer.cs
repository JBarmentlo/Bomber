using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

using Unity.Collections;
using Unity.Networking.Transport;


public class MapDestroyer : MonoBehaviour
{   

    private static MapDestroyer _instance;
    public static MapDestroyer Instance { get { return _instance; } }

    public  Tilemap     tilemap;
    public  Tile        wallTile;
    public  Tile        destructibleTile;
    public  GameObject  explosionPrefab;
    
    
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    void OnDestroy()
    {
        if (_instance == this){
            _instance = null;
        }
    }


    public void Explode(Vector2 worldPos, int boomDist = 0)
    {
        Vector3Int  originCell  = tilemap.WorldToCell(worldPos);
        ExplodeCell(originCell);
        
    }

    private bool ExplodeCell(Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);
        if (tile == wallTile)
        {
            return true;
        }
        if (tile == destructibleTile)
        {
            tilemap.SetTile(cell, null);
            return true;
        }

        Vector3 centerPos = tilemap.GetCellCenterWorld(cell);
        Instantiate(explosionPrefab, centerPos, Quaternion.identity);
        return true;
    }
}
