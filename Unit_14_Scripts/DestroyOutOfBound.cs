using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float topBound = 30.0f;
    public float bottomBound = -25.0f;

    private ScoreManager scoreManager;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Awake()
    {
        // Establish the score text objects.
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy objects when they moves too high.
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        // When an object moves too low...
        else if (transform.position.z < bottomBound)
        {
            // ...if it's an enemy, Game Over.
            if (this.gameObject.CompareTag("Enemy"))
            {
                gameManager.PlayEnd();
                gameManager.isGameOver = true;
                scoreManager.LosePoints(this.gameObject.name);
                Debug.Log("Game Over!");
            }
            // ...destroy it.
            Destroy(gameObject);
        }
    }
}
