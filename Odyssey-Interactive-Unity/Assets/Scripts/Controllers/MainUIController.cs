using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIController : MonoBehaviour {

    public void OnPressPlay() {
        Global.Scenes.GAME.show();
    }

    public void OnPressQuit() {
        Application.Quit();
    }

}
