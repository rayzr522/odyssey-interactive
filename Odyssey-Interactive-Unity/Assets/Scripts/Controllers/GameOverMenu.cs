using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {
    public Text titleText;
    public Text causeText;

    private string GetDeathMessage(DeathReason reason) {
        switch (reason) {
            case DeathReason.WHIRLPOOL: return "You were sucked in by Charbydis!";
            case DeathReason.CLIFFS: return "You crashed into Scylla's cliffs!";
            case DeathReason.EATEN: return "Scylla gobbled you up!";
            default: return "";
        }
    }

    public void Show(GameResults results) {
        if (!results.won) {
            titleText.text = "You Lost";
            causeText.text = GetDeathMessage(results.deathReason);
        } else {
            titleText.text = "You Won!";
            causeText.text = "";
        }

        // Aaaaand display
        gameObject.SetActive(true);
    }
}
