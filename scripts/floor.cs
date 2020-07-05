using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{


    private GameObject floorManager;

    //if the player passed the road, so tell your managers to give him a point and to create a new road
    //and stop be active 
    public void endPath()            
    {
        floorManager.GetComponent<floorManager>().newPath();
        GameObject.FindObjectOfType<manager>().addPoint();
        gameObject.SetActive(false);
        

    }

    public void FillManagers(GameObject newFloorManager)    //set a floorManager
    {
        floorManager = newFloorManager;
    }




}
