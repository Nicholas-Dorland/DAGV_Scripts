using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Set the bounds of the area.
    private float topBound = 30;
    private float lowerBound = -10;

    // Update is called once per frame
    void Update()
    {
        // Destroy objects if they are too upward or downward.
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
