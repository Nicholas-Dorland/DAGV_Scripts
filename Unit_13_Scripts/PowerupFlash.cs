using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupFlash : MonoBehaviour
{
    public Material color1;
    public Material color2;

    private float swapPoint = 5.0f;
    private float posZ;
    private bool isStartColor;
    public bool hasSwapped;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = color1;
        isStartColor = true;
        hasSwapped = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Based on the object's position...
        var position = gameObject.transform.position;
        posZ = Mathf.Round(position.z);
        float timing = posZ % swapPoint;

        // ...swap between to colors.
        if (!hasSwapped)
        {           
            hasSwapped = true;
            SwitchColor();
        }
        else if (timing != 0)
        {
            hasSwapped = false;
        }
    }

    // Change between two colors.
    void SwitchColor()
    {
        if (isStartColor)
        {
            GetComponent<Renderer>().material = color2;
            isStartColor = false;
        }
        else
        {
            GetComponent<Renderer>().material = color1;
            isStartColor = true;
        }
    }
}
