using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLimiter : MonoBehaviour {

    private string myTag;
    private RoomSpawner roomspawn;
    //private RoomTemplates templates;
    private int rand;
    //private GameObject spawnPoint;
    //private float waitTime = 0.1f;

    void Start ()
    {
        //templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        //Destroy(gameObject, waitTime);
        myTag = gameObject.tag;
        roomspawn = GameObject.FindObjectOfType<RoomSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != myTag && roomspawn.spawned == false)
        {
            roomspawn.Respawn();
            //spawnPoint = other.gameObject.transform.Find("SpawnPoint");
            //rand = Random.Range(0, templates.respawnRooms.Length);
            //Instantiate(templates.respawnRooms[rand], other.gameObject.transform.position, templates.respawnRooms[rand].transform.rotation);
            Destroy(transform.root.gameObject);
            Debug.Log("detected bad room match, destroyed it.");
            
        }
    }
}