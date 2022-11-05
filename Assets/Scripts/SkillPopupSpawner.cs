using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPopupSpawner : MonoBehaviour
{
    public GameObject[] SkillPopupButtons;
    public GameObject prefabPopupInfo;
    GameObject popupInfo;
    const float screenImpositionWidth = 1024;
    const float screenImpositionHeight = 768;
    const float screenImpositionAspect = 1.33333f;

    private void Awake()
    {
        foreach (GameObject go in SkillPopupButtons)
        {
            go.GetComponent<Button>().onClick.AddListener(delegate
            {
                SpawnPopupInfo(go.transform);
                Rect screenBounds = new Rect(0f, 0f, Screen.width, Screen.height); // Screen space bounds (assumes camera renders across the entire screen)
                Vector3[] objectCorners = new Vector3[4];
                RectTransform rectPopup = popupInfo.GetComponent<RectTransform>();
                rectPopup.GetWorldCorners(objectCorners);
                for (var i = 0; i < objectCorners.Length; i++)
                    if (!screenBounds.Contains(objectCorners[i])) // if popup partially out of screen
                    {
                        popupInfo.transform.position = new Vector3(popupInfo.transform.position.x, ((float)Screen.height / screenImpositionHeight) *(rectPopup.rect.size.y/2  + 10));;
                        Transform arrow = popupInfo.transform.Find("arrow");
                        arrow.position = new Vector3(arrow.position.x, go.transform.position.y);
                        return;
                    }
            });
        }
    }

    void SpawnPopupInfo(Transform parent)
    {
        if (popupInfo != null) Destroy(popupInfo);
            popupInfo = Instantiate(prefabPopupInfo, parent.position + new Vector3(185 * ( (float)Screen.width / screenImpositionWidth) * (screenImpositionAspect / Camera.main.aspect), -25*((float)Screen.height/ screenImpositionHeight), 0), Quaternion.identity, parent);
    }
}
