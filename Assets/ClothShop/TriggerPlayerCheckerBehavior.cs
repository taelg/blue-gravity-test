using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayerCheckerBehavior : MonoBehaviour
{
    private bool isPlayerInside = false;
    private CharacterBehavior characterBehavior;

    public bool IsPlayerInside() {
        return isPlayerInside;
    }

    public CharacterBehavior GetCharacterInside() {
        return characterBehavior;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            isPlayerInside = true;
            this.characterBehavior = other.GetComponent<CharacterBehavior>();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            isPlayerInside = false;
            this.characterBehavior = null;
        }
    }


}
