using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
    private Vector3 spawnPos = new Vector3(30, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);       // Repeatedly spawn objects.
    }

    // Spawn an obstacle.
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
