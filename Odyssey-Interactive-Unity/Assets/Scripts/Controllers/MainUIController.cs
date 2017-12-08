using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour {
    public Image difficultyButton;
    public Text difficultyText;

    public Text viewButton;

    public Animator mainView;
    public Animator creditsView;

    private bool isMainView = true;

    void Start() {
        UpdateDifficultyLabel();
        UpdateViewButton();
    }

    public void OnPressPlay() {
        Global.Scenes.GAME.show();
    }

    void UpdateDifficultyLabel() {
        difficultyButton.color = Global.difficulty.color;
        difficultyText.text = Global.difficulty.name;
    }

    public void CycleDifficulty() {
        switch (Global.difficulty.id) {
            case 0:
                Global.difficulty = Global.Difficulties.MEDIUM;
                break;
            case 1:
                Global.difficulty = Global.Difficulties.HARD;
                break;
            case 2:
                Global.difficulty = Global.Difficulties.EASY;
                break;
        }

        UpdateDifficultyLabel();
    }

    public void UpdateViewButton() {
        viewButton.text = isMainView ? "Credits" : "Back";
    }
    public void ToggleView() {
        isMainView = !isMainView;

        mainView.SetBool("Hidden", !isMainView);
        creditsView.SetBool("Hidden", isMainView);

        UpdateViewButton();
    }
}
