using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    RectTransform rectTransform;
    Rect safeArea;
    Vector2 minAnchor;
    Vector2 maxAnchor;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        //safeArea = Screen.safeArea;
        //float aspect = Camera.main.aspect;
        float heightSafeAreaDiff = Screen.height - Screen.safeArea.height;
        safeArea = new Rect(Screen.safeArea.x, Screen.safeArea.y - heightSafeAreaDiff, Screen.safeArea.width, Screen.height);

        minAnchor = safeArea.position;
        maxAnchor = minAnchor + safeArea.size;
        minAnchor.x /= Screen.width;
        minAnchor.y /= Screen.height;
        maxAnchor.x /= Screen.width;
        maxAnchor.y /= Screen.height;

        rectTransform.anchorMin = minAnchor;
        rectTransform.anchorMax = maxAnchor;
    }
}
