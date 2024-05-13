using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNPCBehavior : MonoBehaviour
{

    [Header("Internal")]
    [SerializeField] private TriggerPlayerCheckerBehavior triggerOnGetClose;
    [SerializeField] private GameObject activeOnGetClose;
    [SerializeField] private GameObject activeOnInteract;
    [SerializeField] private HairShopPanelBehavior hairPanel;
    [SerializeField] private ClothShopPanelBehavior clothPanel;
    [SerializeField] private ClothShopPanelBehavior hatPanel;

    private void Start() {
        activeOnInteract.SetActive(true);
        activeOnInteract.SetActive(false);
    }
    
    void Update()
    {
        ShowHideGetCloserDialog();
        ShowHideAppearanceShopUI();
    }

    private void ShowHideGetCloserDialog() {
        if (triggerOnGetClose.IsPlayerInside()) {
            activeOnGetClose.SetActive(true);
        } else {
            activeOnGetClose.SetActive(false);
        }
    }

    private void ShowHideAppearanceShopUI() {
        bool isPressingInteractButton = Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton2);

        if (triggerOnGetClose.IsPlayerInside() && isPressingInteractButton) {
            CharacterBehavior character = triggerOnGetClose.GetCharacterInside();
            activeOnInteract.SetActive(!activeOnInteract.activeInHierarchy);

            if (activeOnInteract.activeInHierarchy) {
                hairPanel.Initialize(triggerOnGetClose.GetCharacterInside(), character.GetHairColor(),character.GetHair());
                clothPanel.Initialize(triggerOnGetClose.GetCharacterInside(),character.GetCloth());
                hatPanel.Initialize(triggerOnGetClose.GetCharacterInside(),character.GetHat());
            }
        }
    }
}
