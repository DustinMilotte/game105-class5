using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject goal;

    private int count = 0;
    private int totalPickups;

    // Start runs before the first frame
    private void Start()
    {
        totalPickups = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        Debug.Log("totalPickups " + totalPickups);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    public void GoalReached()
    {
        // get current scene index and add 1 to go to next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HandleUpdateScore()
    {
        count++;
        scoreText.text = "Score: " + count.ToString();

        if (count == totalPickups)
        {
            goal.SetActive(true);
        }
    }


}
