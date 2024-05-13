using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Making an instance of this game manger so it can be called
    // anywhere. Since it's a static variable it's stored in memory
    // for the duration of the runtime.
    public static GameManager instance;

    int score = 0;
    int streak = 0;
    int lives = 3;
    bool gameOver = false;

    public GameObject livesHolder; // Drag and drop LivesPanel here.

    public GameObject gameOverPanel;

    public Text scoreText;
    public Text scoreAmount; // Text is an object type in UnityEngine.UI
    public Text streakText;
    public Text streakAmount;


    // Setting the instance of the GameManger to be this instance.
    private void Awake()
    {
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Calling this function will add to the score
    // and print it to the console to check the
    // functionality.
    public void IncrementScore()
    {
        if (!gameOver) // If the game is not over
        {
            score++;
            scoreAmount.text = score.ToString();
            scoreAmount.color = Color.white;
            scoreText.color = Color.white;

            IncrementStreak(); // Add to the streak
        }
    }

    public void DecrementScore()
    {
        if (!gameOver) // If the game is not over
        {
            if (score >= 1)
            {
                score--;
            }

            scoreAmount.text = score.ToString();
            scoreAmount.color = Color.red;

            DecrementStreak(); // Break the streak

           // Maybe one day I'll figure out how animations work tee hee
           // GameObject.Find("Player").GetComponent<Animator>().Play("Shake");
        }
    }

    public void DecrementLives()
    {
        if (lives > 0)
        {
            lives--;

            // The number of child objects in the livesHolder aligns with how
            // we count the number of lives in the game ie when lives goes down
            // to 2, delete the child object at index 2 (the third heart), then
            // the same when lives go down to 1 and 0: delete the second and
            // first heart.

            livesHolder.transform.GetChild(lives).gameObject.SetActive(false);

            DecrementStreak();
        }

        if (lives <= 0)
        {
            gameOver = true;
            GameOver();
        }
    }

    public void IncrementStreak()
    {
        streak++;
        streakAmount.text = streak.ToString();
        streakAmount.color = Color.white;

        // This code restores a life for every 7 in a row the player gets
        // but only up to the original three lives.
        if (streak % 7 == 0)
        {
            livesHolder.transform.GetChild(lives).gameObject.SetActive(true);
            lives++;
        }
    }

    public void DecrementStreak()
    {
        streak = 0;
        streakAmount.text = streak.ToString();
        streakAmount.color = Color.red;
    }


    public void GameOver()
    {
        ObjectSpawner.instance.StopSpawningObjects();
        //CandySpawner.instance.StopSpawningCandies(); 
        //VeggieSpawner.instance.StopSpawningVeggies(); 

        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false; // Disabling player movement

        gameOverPanel.SetActive(true);

        print("Game over!");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
