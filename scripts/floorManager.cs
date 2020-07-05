using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorManager : MonoBehaviour
{
    //this code is responsible for creating new roads in the right position
    //also he suppose to be responsible for the buss, but the bus might not be sticking for long

    public GameObject bus;      //bus
    private bool canBusMove;

    public GameObject leftPrefab;       //the roads to put
    public GameObject rightPrefab;


    public GameObject manager;          //the manager

    private Vector3 nextPathPoss;       //where and how to put the roads
    private Vector3 nextPathrotation;

    public int pathInTheSameTime = 3;   //how many roads to start with

    void Start()                        
    {
                              
        nextPathPoss = Vector3.zero;            //start building the roads
        nextPathrotation = Vector3.zero;
        for (int i=0; i != pathInTheSameTime; i++)
        {
            newPath();
        }

        canBusMove = true;                  //start the bus and kill it after a while
        Invoke("killBus", 3f);
    }

    void Update()                           //to move the bus in the start
    {
        if(canBusMove)
            bus.transform.position += Vector3.right*Time.deltaTime*5;
    }

    public void newPath()           //add a road and update the place of the next road to be.
    {
        GameObject newPath;
        float new_Y=0;
        if (Random.Range(0, 2) == 0)
        {

            newPath = Instantiate(leftPrefab, nextPathPoss, Quaternion.Euler(nextPathrotation));

            if ((-10 < nextPathrotation.y && nextPathrotation.y < 10) || (-350 < nextPathrotation.y && nextPathrotation.y < -370))
            { nextPathPoss = nextPathPoss + new Vector3(6, 0, 6);}
            else if ((80 < nextPathrotation.y && nextPathrotation.y < 100) || (-280 < nextPathrotation.y && nextPathrotation.y < -260))
            { nextPathPoss = nextPathPoss + new Vector3(6, 0, -6); }
            else if ((170 < nextPathrotation.y && nextPathrotation.y < 190) || (-190 < nextPathrotation.y && nextPathrotation.y < -170))
            {   nextPathPoss = nextPathPoss + new Vector3(-6, 0, -6); }
            else if ((260 < nextPathrotation.y && nextPathrotation.y < 280) || (-100 < nextPathrotation.y && nextPathrotation.y < -80))
            {   nextPathPoss = nextPathPoss + new Vector3(-6, 0, 6);}
            else
                print(nextPathrotation.y);

            new_Y +=Mathf.Floor(nextPathrotation.y - 90) % 360;
        }
        else
        {

            newPath = Instantiate(rightPrefab, nextPathPoss, Quaternion.Euler(nextPathrotation));

            if ((-10 < nextPathrotation.y && nextPathrotation.y < 10) || (-350 < nextPathrotation.y && nextPathrotation.y < -370))
            { nextPathPoss = nextPathPoss + new Vector3(6, 0, -6); }
            else if ((80 < nextPathrotation.y && nextPathrotation.y < 100) || (-280 < nextPathrotation.y && nextPathrotation.y < -260))
            { nextPathPoss = nextPathPoss + new Vector3(-6, 0, -6); }
            else if ((170 < nextPathrotation.y && nextPathrotation.y < 190) || (-190 < nextPathrotation.y && nextPathrotation.y < -170))
            { nextPathPoss = nextPathPoss + new Vector3(-6, 0, 6);}
            else if ((260 < nextPathrotation.y && nextPathrotation.y < 280)||(-100 < nextPathrotation.y && nextPathrotation.y < -80))
            { nextPathPoss = nextPathPoss + new Vector3(6, 0, 6);}
            else
                print(nextPathrotation.y);

            new_Y += Mathf.Floor(nextPathrotation.y + 90) % 360;
        }

        newPath.GetComponent<floor>().FillManagers(this.gameObject);

        nextPathrotation = Vector3.up * new_Y;
    }

    void killBus()      //kill the bus
    {
        canBusMove = false;
        bus.SetActive(false);
    }
}
