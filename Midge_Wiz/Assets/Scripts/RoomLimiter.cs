using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLimiter : MonoBehaviour {

    private string myTag;
    private RoomSpawner roomspawn;
    //private float waitTime = 1f;

    void Start ()
    {
        //Destroy(gameObject, waitTime);
        myTag = gameObject.tag;
        roomspawn = GameObject.FindObjectOfType<RoomSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != myTag && roomspawn.spawned == false)
        {
            
            Destroy(transform.root.gameObject);
            Debug.Log("detected bad room match, destroyed it.");
            
        }
    }
}
