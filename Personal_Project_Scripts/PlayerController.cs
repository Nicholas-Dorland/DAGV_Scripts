using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //All of the important Variables that will be needed for this script.
    [SerializeField] private float moveSpeed = 5f;

    //Establishing important objects.
    private CharacterController controller;

    void Start()
    {
        //Starting points for several objects.
        controller = GetComponent<CharacterController>();
        Debug.Log("Test test!");
    }

    void Update()
    {
        //Rotate the swords if the Left Mouse Button is not being pressed.
        if (!Input.GetMouseButton(0))
        {
            float rotate = Input.GetAxis("Mouse X") * moveSpeed;
            transform.Rotate(0, rotate, 0);

        }

        //Test to distinguish the color the swords should be.
        if (Input.GetAxis("Mouse X") > 0)
        {
            //Debug.Log("Purple!");
        }
        else if (Input.GetAxis("Mouse X") < 0)
        {
            //Debug.Log("Orange!");
        }
    }
}
