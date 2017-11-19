using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public void OnPressPlay()
    {
        Debug.Log("You pressed PLAY");
    }

    public void OnPressQuit()
    {
        Debug.Log("You pressed QUIT");
		Application.Quit();
    }

}
