using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRange = 9.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn enemies at their correct positions.
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for enemies, and spawn next wave if there are none.
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    // Spawn a wave of enemies.
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }


    // Randomly choose where to spawn enemies.
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosx = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosx, 0, spawnPosZ);

        return randomPos;
    }
}
