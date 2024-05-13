using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BlockPlayerInputsOnUIBehavior : MonoBehaviour
{

    [SerializeField] private CharacterBehavior player;
    [SerializeField] private GameObject[] panelsBlockingMovement;


    void Update()
    {
        BlockMovementsOnUIs();
    }

    private void BlockMovementsOnUIs() {
        player.BlockInputDuringUI(isAnyBlockingPanelActive());
    }

    private bool isAnyBlockingPanelActive() {
        foreach (GameObject panel in panelsBlockingMovement) {
            if (panel.activeInHierarchy)
                return true;
        }
        return false;
    }
}
