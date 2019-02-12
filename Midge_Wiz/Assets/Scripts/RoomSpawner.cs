using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    public int openingDir;
    // 1 needs bottom door
    // 2 needs top door
    // 3 needs left door
    // 4 needs right door
    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;
    private float waitTime = 4f;

    private void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Debug.Log("set templates");
        Invoke("Spawn", 0.1f);
        Debug.Log("invoked Spawn");
    }

    public void Spawn()
    {
        if (spawned == false)
            Debug.Log("spawned is flase");
        {
            if (openingDir == 1)
            {
                // spawn room with bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDir == 2)
            {
                // spawn room with top door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDir == 3)
            {
                // spawn room with left door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDir == 4)
            {
                // spawn room with right door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
            //Debug.Log("set spawned to true");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("UnSpawnable"))
        {
            spawned = true;
        }
        /*else
        {
            Invoke("Spawn", 0.4f);
        }*/
    }
}
