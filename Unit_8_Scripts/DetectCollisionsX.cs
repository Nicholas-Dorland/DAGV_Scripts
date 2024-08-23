using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    // When objects collide, desetroy them.
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Debug.Log("Hit!");
    }
}
