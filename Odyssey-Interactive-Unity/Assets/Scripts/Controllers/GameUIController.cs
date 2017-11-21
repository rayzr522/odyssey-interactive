using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {

    int currentHealth = 6;
    public Image healthbarFilled;

    public Image pauseMenu;

    public void SetHealth(int health) {
        healthbarFilled.rectTransform.sizeDelta = new Vector2(25 * health, 35);
    }

    void Update() {
        if (Input.GetMouseButtonDown(1)) {
            if (--currentHealth < 0) {
                currentHealth = 0;
            }

            SetHealth(currentHealth);
        }
    }

    public void ShowPauseMenu() {
        pauseMenu.gameObject.SetActive(true);
    }

    public void HidePauseMenu() {
        pauseMenu.gameObject.SetActive(false);
    }

    public void OnPressPause() {
        GameController.instance.TogglePlayPause();
    }

    public void OnPressBack() {
        // TODO: Do cleanup, maybe?
        Global.Scenes.MAIN.show();
    }

    public void OnPressRestart() {
        GameController.instance.Restart();
    }

    public void OnPressResume() {
        // Note, this is the same as the pause button (for now), so imma just call
        OnPressPause();
    }
}
