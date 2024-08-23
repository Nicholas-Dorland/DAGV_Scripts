using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 25;
    public float xRange = 30;
    public bool hasPowerup;
    public Transform blaster;
    public GameObject lazerBolt;
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Move left and right based on input.
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        powerupIndicator.transform.position = transform.position;       // Move powerup indicator with player.

        // Stop the player if they go too far left...
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        // ...or too far right.
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Shoot a projectile when space is pressed.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(lazerBolt, blaster.transform.position, lazerBolt.transform.rotation);
        }
    }

    // When interacting with an object...
    private void OnTriggerEnter(Collider other)
    {
        // ...give a shield.
        if (other.gameObject.CompareTag("Shield"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
        }
        // ...if it's an enemy...
        else if (other.gameObject.CompareTag("Enemy"))
        {
            // ...destroy enemy (with shield).
            if (hasPowerup)
            {
                hasPowerup = false;
                powerupIndicator.SetActive(false);
                Destroy(other.gameObject);
            }
            // ...destroy player.
            else
            {
                Debug.Log("Game Over!");
                Destroy(gameObject);
            }
        }
    }
}
