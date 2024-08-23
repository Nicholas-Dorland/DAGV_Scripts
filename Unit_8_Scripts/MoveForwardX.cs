using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardX : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        // Move forward at a set speed.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
