using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {

    int currentHealth = 6;
    public Image healthbarFilled;

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
}
