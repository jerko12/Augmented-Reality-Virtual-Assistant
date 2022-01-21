using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUiElement : MonoBehaviour
{
    [SerializeField] private GameObject ui_element;
    private Camera cam;
    private void Start()
    {
        cam = Camera.main; 
    }

    public void SpawnUIElementOnscreenLocation(Vector2 screenPos)
    {
        GameObject spawnedElement =  Instantiate(ui_element, transform);
        spawnedElement.transform.position = cam.ScreenToWorldPoint(screenPos);
    }
}
