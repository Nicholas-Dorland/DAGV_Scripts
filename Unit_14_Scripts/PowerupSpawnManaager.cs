using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawnManaager : MonoBehaviour
{
    public GameObject powerUp;

    private float spawnRangeX = 20.0f;
    private float spawnPosZ = 25.0f;

    private void Start()
    {
        // Spawn powerups.
        InvokeRepeating("RandomSpawner", 3.0f, 2.0f);
    }

    // Spawn powerups at random positions.
    void RandomSpawner()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 2, spawnPosZ);
        Instantiate(powerUp, spawnPos, powerUp.transform.rotation);
    }

}
