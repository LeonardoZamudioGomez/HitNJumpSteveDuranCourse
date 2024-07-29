using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // To be able to work with the game scenes.

public class Game : MonoBehaviour
{
    public static Game obj; // Singleton for the game script.

    public int maxLives = 3; // The maximum number of lives for the user.

    public bool gamePaused = false; // Variable to control if the game is paused.
    public int score = 0; // The score.

    void Awake() // Singleton.
    {
        obj = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false; // To define that our game will not be paused.
    }

    public void AddScore(int ScoreGive) // Public function to add score.
    {
        score += ScoreGive; // It is the variable that we will recover.
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // What this line does is restart the current scene.
    }

    void OnDestroy() // Singleton.
    {
        obj = null;
    }
}
