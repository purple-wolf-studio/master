using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camera : MonoBehaviour
{
    //all this code is about the player if he wants the camera to be farther

    public static int Distance=0;
    public Text manuText;

    private void Start()
    {
        transform.localPosition = transform.localPosition + new Vector3(-Distance, Distance, 0);
    }

    public void addDistance(int addDistance)
    {
        if ((Distance + addDistance) == -1)
            return;
        Distance += addDistance;
        transform.localPosition = transform.localPosition + new Vector3(-addDistance, addDistance, 0);
        manuText.text = (Distance).ToString();
    }

}
