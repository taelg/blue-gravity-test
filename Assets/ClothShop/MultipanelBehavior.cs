using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultipanelBehavior : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private GameObject[] panels;
    [SerializeField] private Sprite buttonBackground;
    [SerializeField] private Sprite selectedButtonBackground;

    private void Start() {
        if (buttons.Length != panels.Length)
            Debug.LogError("MultipanelBehavior needs the same number of buttons and panels to work properly.");

        int index = 0;
        foreach (var button in buttons) {
            int buttonIndex = index;
            button.onClick.AddListener(() => OnClickButton(buttonIndex));
            index++;
        }
    }

    private void OnEnable() {
        if (buttons.Length > 0)
            OnClickButton(0);
    }

    private void OnClickButton(int index) {
        DeactiveAllButton();
        DeactiveAllPanels();
        ActivePanelByIndex(index);
    }

    private void DeactiveAllButton() {
        foreach (var button in buttons) {
            button.GetComponent<Image>().sprite = buttonBackground;
        }
    }

    private void DeactiveAllPanels() {
        foreach (var panel in panels) {
            panel.SetActive(false);
        }
    }

    private void ActivePanelByIndex(int index) {
        buttons[index].GetComponent<Image>().sprite = selectedButtonBackground;
        panels[index].SetActive(true);
    }


}


