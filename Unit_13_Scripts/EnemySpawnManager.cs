using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] ufoPrefabs;

    private float spawnRangeX = 20.0f;
    private float spawnPosZ = 25.0f;

    private void Start()
    {
        // Repeatedly spawn enemies.
        InvokeRepeating("RandomSpawner", 2.0f, 0.5f);
    }

    // Spawn random enemies at random positions.
    void RandomSpawner()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 2, spawnPosZ);
        int ufoIndex = Random.Range(0, ufoPrefabs.Length);
        Instantiate(ufoPrefabs[ufoIndex], spawnPos, ufoPrefabs[ufoIndex].transform.rotation);
    }
}
