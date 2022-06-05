using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    // get reference to UI elements
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;

    private void Awake()
    {
        // when game starts, pause it b/c we want to hit play button to begin.
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            // add .gameObject to the end to reference whole G.O. and not just the Pipes script component
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        // Time does not update since everything is multiplied by deltaTime.
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void GameOver()
    {
        // set the GameObject to active.
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
