using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endPath : MonoBehaviour
{
    public GameObject floor;
    private void OnTriggerEnter(Collider other)     //if the player has ended this road so delete it
    {
        if (other.tag == "Player")
        {
            floor.GetComponent<floor>().endPath();
        }

    }
}
