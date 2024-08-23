using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Created a script to rotate the propeller. Bonus Challenge.*/
public class SpinPropellerX : MonoBehaviour
{
    private float spinSpeed = 200f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*Rotate the object around the forward axis at a set speed.*/
        transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
    }
}
