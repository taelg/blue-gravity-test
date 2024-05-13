using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class HairShopPanelBehavior : MonoBehaviour
{

    [Header("Configurable")]
    [SerializeField] private Color[] hairColors;
    [SerializeField] private AppearanceItem[] hairs;

    [Header("Internal")]
    [SerializeField] private GameObject shopButtonPrefab;
    [SerializeField] private GameObject colorButtonPrefab;
    [SerializeField] private Transform content;
    [SerializeField] private Transform colorsContent;

    private CharacterBehavior character;

    public void Initialize(CharacterBehavior character, Color color, SpriteLibraryAsset hairAsset) {
        this.character = character;
        InitializeHairColors(color);
        InitializeHairs(hairAsset);
    }
    
    private void InitializeHairColors(Color color) {
        ClearContentPanel(colorsContent);
        foreach (var hairColor in hairColors) {
           HairColorButtonBehavior hairColorButton = Instantiate(colorButtonPrefab, colorsContent).GetComponent<HairColorButtonBehavior>();
           
           hairColorButton.InitializeColor(hairColor, character);
        }
    }
    
    private void InitializeHairs(SpriteLibraryAsset hairAsset) {
        ClearContentPanel(content);
        foreach (var hair in hairs) {
           ShopButtonBehavior hairButton = Instantiate(shopButtonPrefab, content).GetComponent<ShopButtonBehavior>();
           hairButton.InitializeButton(character, AppearanceSlot.Hair, hair.asset, hair.icon, hair.price, false, false, hair.available);

           if (hair.asset == hairAsset)
                hairButton.GetComponent<Button>().Select();
        }
    }

    private void ClearContentPanel(Transform contentPanel) {
        foreach (Transform child in contentPanel.GetComponentInChildren<Transform>()) {
            if (child != this.transform)
                Destroy(child.gameObject);
        }
    }

}