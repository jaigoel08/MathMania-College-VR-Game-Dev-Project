using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedSpawn : MonoBehaviour
{
    public GameObject spawn;
    public bool stopspawning = false;
    public float spawnTime;
    public float spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObject()
    {
        Instantiate(spawn, transform.position, transform.rotation);
        if (stopspawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
