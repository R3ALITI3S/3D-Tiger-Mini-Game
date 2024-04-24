using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // see this
using TMPro; // new

public class GameManager : MonoBehaviour
{
    public Image imageScore;
    public GameObject playButton;
    public CharacterMovement player;
    public GameObject text;

    private void Awake() // starts on awake
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play() // plays everything
    {
        playButton.SetActive(false);
        text.SetActive(false);

        Time.timeScale = 1f; // the game is now working
        player.enabled = true; // it is now possible to use the player
    }

    public void Pause() // pauses everything
    {
        Time.timeScale = 0f; // the game is now 'paused'
        player.enabled = false; // the player is now not enabled, not updated
    }


    // Start is called before the first frame update
    void Start()
    {
        imageScore.enabled = false; // as it is not shown
    }
    
    public void StartIEnumerator () 
    {
        StartCoroutine(showscore()); // used together with an IEnumerator, 
        // cant ref a Coroutine outiside of current script?
    }

    IEnumerator showscore() // Kører samtidigt med en Void Update // takes the time of the device 
    {
        imageScore.enabled = true; // shows the image because it is true

        yield return new WaitForSeconds(2); // has a tiny pause, return type yield

        imageScore.enabled = false; // then the image is false again
    }
    
}
