using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimerX : MonoBehaviour
{
    public float totalTime = 60;
    public TextMeshProUGUI timerText;
    public GameObject timer;

    private GameManagerX gameManagerX;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        timer.SetActive(false);
    }

    void Update()
    {
        // Update the timer based on time left.
        totalTime -= Time.deltaTime;

        // Show, in whole numbers, the time left...
        if (totalTime > 0)
        {
            Debug.Log(totalTime);
            timerText.text = "Time: " + Mathf.Round(totalTime);
        }
        // ...until there is no more time.
        else
        {
            totalTime = 0;
            timerText.text = "Time: 0";
            gameManagerX.GameOver();
        }
    }

    // Start the timer.
    public void StartTimer()
    {
        timer.SetActive(true);
    }

    // Stop the timer.
    public void StopTimer()
    {
        timer.SetActive(false);
    }
}
