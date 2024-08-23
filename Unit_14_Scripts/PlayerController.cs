using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform blaster;
    public GameObject lazerBolt;
    public GameObject powerupIndicator;
    public AudioClip shootSound;
    public float horizontalInput;

    private float speed = 25;
    private float xRange = 30;
    private bool hasPowerup;
    private GameManager gameManager;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        hasPowerup = false;
        powerupIndicator.SetActive(false);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player based on input.
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        powerupIndicator.transform.position = transform.position;       // Move the powerup with the player.

        // Stop the player if they move too far left...
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        // ...or right.
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Shoot when space is pressed.
        if (Input.GetKeyDown(KeyCode.Space) && !gameManager.isGameOver)
        {
            playerAudio.PlayOneShot(shootSound, 1.0f);
            Instantiate(lazerBolt, blaster.transform.position, lazerBolt.transform.rotation);
        }
    }

    // When colliding with objects...
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
                gameManager.PlayDestroy();
                hasPowerup = false;
                powerupIndicator.SetActive(false);
                Destroy(other.gameObject);
            }
            // ...destroy player.
            else
            {
                gameManager.PlayExplode();
                Debug.Log("Game Over!");
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
