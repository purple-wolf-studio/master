using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    private static int addSpeed=0;          //for the player to change the Speed of the boy
    public Text manuText;

    public int moveSpeed = 1;               //stuf for the running of the boy
    private Vector3 direction;
    private bool canMakeATurn;
    private bool canRun;
    private Vector3 faceTo;
    public float rotatSspeed;


    private Vector3 startPosition;          //to check for swipes on the screen
    private Vector3 endPosition;



    void Start()                            //setups
    {
        faceTo = transform.eulerAngles;
        direction = Vector3.right;
        canMakeATurn = true;
        canRun = false;
        Invoke("startRun", 1f);
    }
    void Update()
    {
        if(canRun)                      //the boy running
            move();

                                        //to make a smooth turn
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(faceTo), Time.deltaTime*rotatSspeed);
    }

    private void move()
    {
        transform.position += Time.deltaTime *direction * (moveSpeed- addSpeed);    //move

        //from here its about turns
        if (!canMakeATurn)                                           
            return;


        Vector3 temp = transform.eulerAngles;
        float num;
        swipeDirection swipe = this.swipe();
        if (Input.GetKeyDown("left") || swipe == swipeDirection.left)
        {
            temp.y -= 90;
            num = direction.z;
            direction.z = direction.x;
            direction.x = -num;
            canMakeATurn = false;
            faceTo = temp;
            Invoke("anableTurn", 0.3f);

        }
        if (Input.GetKeyDown("right") || swipe == swipeDirection.right)
        {
            temp.y += 90;
            num = direction.z;
            direction.z = -direction.x;
            direction.x = num;
            canMakeATurn = false;
            faceTo = temp;
            Invoke("anableTurn", 1f);

        }
    }

    void anableTurn()       //to be sure the player dont accidentally make 2 turn in the same time
    {
        canMakeATurn = true;
    }


    enum swipeDirection     //the kind of swipes we can get
    {
        left,
        right,
        none
    }

    swipeDirection swipe()      //to ditect swipes on the screen
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPosition = Input.mousePosition;
        }

        if (startPosition != endPosition)
        {
            if ((startPosition != Vector3.zero) && (endPosition != Vector3.zero))
            {
                if (startPosition.x < endPosition.x - 50)
                {
                    startPosition = endPosition = Vector3.zero;
                    return swipeDirection.right;

                }
                if (startPosition.x > endPosition.x + 50)
                {
                    startPosition = endPosition = Vector3.zero;
                    return swipeDirection.left;

                }
                
            }

        }
        return swipeDirection.none;
    }


    void startRun()         //to give the bus a had start
    {
        canRun = true;
    }

    public void changeSpeed(int speed)      //for the player to make the boy faster/slower
    {
        addSpeed -= speed;
        if (addSpeed == moveSpeed)
            addSpeed--;
        manuText.text = (moveSpeed - addSpeed).ToString();
    }




}
