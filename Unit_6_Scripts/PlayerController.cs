using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //All of the important Variables that will be needed for this script.
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float height = 2;
    [SerializeField] private float crouchHeight = 1;

    //Establishing important objects.
    private CharacterController controller;
    private Vector3 moveDirection;
    private bool isJumping;

    void Start()
    {
        //Starting points for several objects.
        controller = GetComponent<CharacterController>();
        Debug.Log("Test test!");
        isJumping = true;
        controller.height = height;
    }

    void Update()
    {
        //Set up the Velocity.
        var velocity = new Vector3(0, 0, 0);

        //If the player is crouching...
        if (Input.GetButton("Crouch"))
        {
            float horiz = Input.GetAxis("Horizontal");
            float vert = Input.GetAxis("Vertical");

            velocity.x = horiz * (moveSpeed - 2);
            velocity.z = vert * (moveSpeed - 2);

            controller.height = crouchHeight;
            isJumping = true;
        }
        //If the player is sprinting...
        else if (Input.GetButton("Sprint"))
        {
            float horiz = Input.GetAxis("Horizontal");
            float vert = Input.GetAxis("Vertical");

            velocity.x = horiz * (moveSpeed + 3);
            velocity.z = vert * (moveSpeed + 3);
        }
        //Normal movement
        else
        {
            float horiz = Input.GetAxis("Horizontal");
            float vert = Input.GetAxis("Vertical");

            velocity = new Vector3(horiz, 0, vert) * moveSpeed;
        }

        //Rotate the camera if the Left Mouse Button is not being pressed.
        if (!Input.GetMouseButton(0))
        {
            //transform.eulerAngles += moveSpeed * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            float rotate = Input.GetAxis("Mouse X") * moveSpeed;
            transform.Rotate(0, rotate, 0);
        }

        //Gravity in the air.
        if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
            isJumping = true;
        }
        //Gravity on the ground.
        else
        {
            moveDirection.y = 0;
            isJumping = false;
        }

        //Jumping mechanics. Let's-a-go!
        if (Input.GetButton("Jump"))
        {
            if (!Input.GetButton("Crouch"))
            {
                if (controller.isGrounded || !isJumping)
                {
                    moveDirection.y = jumpForce;
                    isJumping = true;
                }
            }
        }

        //Move the character lower if crouching.
        if (!Input.GetButton("Crouch"))
        {
            if (controller.height < height)
            {
                controller.height += height * Time.deltaTime;
                if (controller.height > height)
                {
                    controller.height = height;
                }
            }
        }

        //Take movements and apply them to character.
        var move = moveDirection + velocity;
        controller.Move(move * Time.deltaTime);
    }
}
