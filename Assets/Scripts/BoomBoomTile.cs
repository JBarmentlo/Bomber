using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoomBoomTile : MonoBehaviour
{
    public  float           fuseTime    = 2.0f;
    public  MapDestroyer    mapDestroyer;
    private bool            explode     = false;
    private Tilemap         tilemap;

    void Start()
    {
        tilemap = GetComponentInParent<Tilemap>();
        Debug.Log("Getting tile");
        Debug.Log(tilemap.GetTile(new Vector3Int(0, 0, 0)));
    }

    void Update()
    {
        fuseTime -= Time.deltaTime;
        if (fuseTime <= 0f){
            // mapDestroyer.Explode()
            MapDestroyer.Instance.Explode(transform.position);
            // FindObjectOfType<MapDestroyer>().Explode(transform.position); // ! USE SINGLETON
            Debug.Log("EXPLODEasdasd");
            Destroy(gameObject);
        }
    }

}
