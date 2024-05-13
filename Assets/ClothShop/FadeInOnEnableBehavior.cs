using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOnEnableBehavior : MonoBehaviour
{

    [SerializeField] private float fadeInSpeed = 0.01f;

    private void OnEnable() {
        StartCoroutine(FadeInOnEnable());
    }

    private IEnumerator FadeInOnEnable() {
        this.transform.localScale = Vector2.zero;

        while (this.transform.localScale.x < 1.1f) {
            this.transform.localScale = new Vector2(this.transform.localScale.x + fadeInSpeed, this.transform.localScale.y + fadeInSpeed);
            yield return new WaitForEndOfFrame();
        }

        while (this.transform.localScale.x > 1f) {
            this.transform.localScale = new Vector2(this.transform.localScale.x - fadeInSpeed, this.transform.localScale.y - fadeInSpeed);
            yield return new WaitForEndOfFrame();
        }
        
    }

    

    
}
