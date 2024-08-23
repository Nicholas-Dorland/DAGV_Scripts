using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCenter : MonoBehaviour
{
    public float speed;
    private GameObject player;
    private Vector3 centerPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        centerPoint = new Vector3(0f, 1f, 0f);

        transform.LookAt(centerPoint);
        transform.Rotate(90f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        //transform.Translate(lookDirection * speed * Time.deltaTime);
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position == player.transform.position)
        {
            Destroy(gameObject);
        }
    }
}
