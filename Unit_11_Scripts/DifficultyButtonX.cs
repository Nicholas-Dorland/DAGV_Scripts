using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonX : MonoBehaviour
{
    public int difficulty;

    private Button button;
    private GameManagerX gameManagerX;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        // Set up a button and determine what is pressed.
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    // When a button is clicked, call the StartGame() method and pass it the difficulty value (1, 2, 3) from the button 
    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        gameManagerX.StartGame(difficulty);
    }



}
