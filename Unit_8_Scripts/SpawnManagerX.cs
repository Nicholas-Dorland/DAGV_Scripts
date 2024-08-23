using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    // Important Variables.
    public GameObject[] ballPrefabs;        // An array of objects, in this case balls.

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        // Set the rest of the code into motion.
        Invoke("SpawnRandomBall", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // Spawn a random ball from an array
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

        // Randomize the spawnInterval
        spawnInterval = Random.Range(3, 6);

        // Spawn a new ball
        Invoke("SpawnRandomBall", spawnInterval);
    }

}
