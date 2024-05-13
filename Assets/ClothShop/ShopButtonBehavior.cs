using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class ShopButtonBehavior : MonoBehaviour
{
    [Header("Internal")]
    [SerializeField] private Image shopItemBackground;
    [SerializeField] private Image shopItemIcon;
    [SerializeField] private TMP_Text shopItemText;
    [SerializeField] private Sprite backgroundEquipped;
    [SerializeField] private Sprite backgroundOwned;
    [SerializeField] private Sprite backgroundBuy;
    [SerializeField] private Sprite backgroundUnavailable;
    [SerializeField] private Button button;
    [SerializeField] private Transform icon;
    private SpriteLibraryAsset hairAsset;
    private CharacterBehavior character;

    public void InitializeButton(CharacterBehavior character, AppearanceSlot slotType, SpriteLibraryAsset hairAsset, Sprite shopIcon, int hairPrice, bool owned, bool equipped, bool available) {
        this.character = character;
        this.hairAsset = hairAsset;
        shopItemIcon.sprite = shopIcon;
        shopItemBackground.sprite = GetShopBackgroundByStatus(owned, equipped, available);
        shopItemText.text = GetShopItemTextByStatus(hairPrice, owned, equipped, available);
        button.enabled = available;
        button.onClick.AddListener(() => OnClickHairButton(character, slotType));
        FixItemHeightBySlotType(slotType);
        
    }


    public void OnClickHairButton(CharacterBehavior character, AppearanceSlot slot) {
        character.SetAppearance(hairAsset, slot);
    }

    public SpriteLibraryAsset GetAppearanceAsset() {
        return hairAsset;
    }

    private void FixItemHeightBySlotType(AppearanceSlot slotType) {
        if (slotType == AppearanceSlot.Cloth)
            icon.localPosition = new Vector2(icon.localPosition.x, 5);
    }

    private string GetShopItemTextByStatus(int hairPrice, bool owned, bool equipped, bool available) {
        string shopItemText = "$" + hairPrice;
        shopItemText = owned ? "Equipar" : shopItemText;
        shopItemText = equipped ? "Equipado" : shopItemText;
        return available ? shopItemText : "Indisponível";
    }

    private Sprite GetShopBackgroundByStatus(bool owned, bool equipped, bool available) {
        Sprite shopItemSprite = backgroundBuy;
        shopItemSprite = owned ? backgroundOwned : shopItemSprite;
        shopItemSprite = equipped ? backgroundOwned : shopItemSprite;
        return available ? shopItemSprite : backgroundUnavailable;
    }
    
}
