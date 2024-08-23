using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;        /*Assigned the FollowPlayerX Script to the camera. Challenge 5.*/
    private Vector3 offset = new Vector3(25f, 0f, 5f);  /*Defined the vector for the offset. Challenge 4.*/

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}
