using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
    private int points;
    public Text Score;


    void Start()            //setups
    {
        Time.timeScale = 1;
        points = 0;
    }



    public void endGame()           //start a new game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void addPoint()          //in the end of every road, give the player a point
    {
        points++;
        Score.text = "Score:" + points;
    }
}
