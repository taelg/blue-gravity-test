using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentPanelBehavior : MonoBehaviour
{
    private void OnEnable()
    {
        ResetContentToTop();

    }

    private void ResetContentToTop() {
        float contentHeight = GetComponent<RectTransform>().rect.height;
        transform.position = new Vector2(transform.position.x, -contentHeight);
    }

}
