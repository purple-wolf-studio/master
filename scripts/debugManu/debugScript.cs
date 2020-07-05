using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debugScript : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;

    public GameObject[] parts;

    public void onOpen()        //stop the game and update the numbers to show the player
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        player.GetComponent<player>().changeSpeed(0);
        camera.GetComponent<camera>().addDistance(0);

    }


    public void onClose()       //close the window and continue the game
    {

        gameObject.SetActive(false);
        Time.timeScale = 1;

    }
}
