using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 0.3f;             /*Changed the values to private, and managed the values to be reasonable. Challenge 2.*/
    private float rotationSpeed = 100f;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);       /*Changed from Vector3.back to Vector3.forward. Challenge 1.*/

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * verticalInput * rotationSpeed * Time.deltaTime);   /*Added the verticalInput to tilt the plane based on input. Challenge 3.*/
    }
}
