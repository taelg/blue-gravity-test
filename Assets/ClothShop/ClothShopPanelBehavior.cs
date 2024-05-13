using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class ClothShopPanelBehavior : MonoBehaviour
{
    [Header("Configurable")]
    [SerializeField] private AppearanceSlot slotType;
    [SerializeField] private AppearanceItem[] appearances;

    [Header("Internal")]
    [SerializeField] private GameObject shopButtonPrefab;
    [SerializeField] private Transform content;

    private CharacterBehavior character;

    public void Initialize(CharacterBehavior character, SpriteLibraryAsset appearanceAsset) {
        this.character = character;
        InitializeAppearances(appearanceAsset);
    }
    
    private void InitializeAppearances(SpriteLibraryAsset appearanceAsset) {
        ClearContentPanel(content);
        foreach (var appearance in appearances) {
           ShopButtonBehavior appearanceButton = Instantiate(shopButtonPrefab, content).GetComponent<ShopButtonBehavior>();
           appearanceButton.InitializeButton(character, slotType, appearance.asset, appearance.icon, appearance.price, false, false, appearance.available);

           if (appearance.asset == appearanceAsset)
                appearanceButton.GetComponent<Button>().Select();
        }
    }

    private void ClearContentPanel(Transform contentPanel) {
        foreach (Transform child in contentPanel.GetComponentInChildren<Transform>()) {
            if (child != this.transform)
                Destroy(child.gameObject);
        }
    }

}


[Serializable]
public class AppearanceItem {
    public SpriteLibraryAsset asset;
    public Sprite icon;
    public int price;
    public bool available;
}
