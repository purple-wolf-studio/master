using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallTriger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)         //the player tuched the walls, the game has end
    {
        if (other.tag == "Player")
            GameObject.FindObjectOfType<manager>().endGame();
    }
}
