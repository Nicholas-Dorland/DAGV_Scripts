using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    //public GameObject orangePrefab;
    //public GameObject purplePrefab;
    private float spawnDelay = 2;
    private float spawnInterval = 1;
    private float radius = 15.0f;
    private Vector3 centerPoint;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        centerPoint = new Vector3(0, 1, 0);
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Spawn obstacles
    void SpawnObjects()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = RandomPointOnCircleEdge();
        int index = Random.Range(0, objectPrefabs.Length);

        // If game is still active, spawn new object
        //if (!playerControllerScript.gameOver)
        //{
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        //}

    }

    private Vector3 RandomPointOnCircleEdge()
    {
        float radians = Random.Range(0, 360);
        float vertical = Mathf.Sin(radians);
        float horizontal = Mathf.Cos(radians);
        Vector3 spawnDir = new Vector3(horizontal, 0, vertical);
        Vector3 spawnPos = centerPoint + spawnDir * radius;

        return spawnPos;
    }
}