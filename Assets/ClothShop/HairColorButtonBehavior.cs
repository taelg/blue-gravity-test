using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HairColorButtonBehavior : MonoBehaviour
{
    [Header("Internal")]
    [SerializeField] Button button;
    [SerializeField] Image hairColorIcon;


    public void InitializeColor(Color color, CharacterBehavior character) {
        hairColorIcon.color = color;
        button.onClick.AddListener(() => SelectHairColor(color, character));
    }

    public void SetHairIcon(Sprite sprite) {
        hairColorIcon.sprite = sprite;
    }

    private void SelectHairColor(Color color, CharacterBehavior character) {
        character.SetHairColor(color);
    }
    
}
