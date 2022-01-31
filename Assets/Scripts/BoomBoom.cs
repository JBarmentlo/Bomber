using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBoom : MonoBehaviour
{
    public  float           fuseTime    = 2.0f;
    public  MapDestroyer    mapDestroyer;

    void Update()
    {
        fuseTime -= Time.deltaTime;
        if (fuseTime <= 0f){
            // mapDestroyer.Explode()
            MapDestroyer.Instance.Explode(transform.position);
            // FindObjectOfType<MapDestroyer>().Explode(transform.position); // ! USE SINGLETON
            Debug.Log("EXPLODE");
            Destroy(gameObject);
        }
    }

}
