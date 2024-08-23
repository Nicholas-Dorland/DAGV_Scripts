using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float spaceDelay = 2.0f;
    private bool canSpace = true;
    private float timeSinceSpace = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // Set a delay on pressing space
        if (canSpace == false)
        {
            timeSinceSpace += Time.deltaTime;
            if (timeSinceSpace > spaceDelay)
            {
                canSpace = true;
            }
        }
        // On spacebar press, send dog
        if (canSpace == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                canSpace = false;       // Sets a delay on the time between Spacebar presses.
                timeSinceSpace = 0.0f;
            }
        }
    }
}
