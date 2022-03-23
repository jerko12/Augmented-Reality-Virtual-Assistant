using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_Element : MonoBehaviour
{
    public string uiElementName = "";
    public bool autoHide = false;

    public void Start()
    {
        UIManager.Instance.AddUIElement(uiElementName,this);
        if (autoHide) gameObject.SetActive(false);
    }
    
}
