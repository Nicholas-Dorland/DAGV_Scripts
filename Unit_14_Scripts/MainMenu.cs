using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneToLoad;
    public AudioClip pressStart;
    public AudioClip pressQuit;

    private AudioSource buttonPress;

    // Start is called before the first frame update
    private void Start()
    {
        buttonPress = GetComponent<AudioSource>();
    }

    // Start game when Start is pressed.
    public void StartGame()
    {
        buttonPress.PlayOneShot(pressStart, 1.0f);
        Invoke("ChangeScene", 0.5f);
    }

    // Go to the game screen.
    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
        Debug.Log("New Scene Loaded!");
    }

    // Update is called once per frame
    public void QuitGame()
    {
        // Play a noise when Quit is pressed.
        buttonPress.PlayOneShot(pressQuit, 1.0f);
        Application.Quit();
        Debug.Log("Quit Game!");
    }
}
