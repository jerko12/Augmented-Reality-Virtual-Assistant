using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    [SerializeField] private string id = "";
    [SerializeField] bool hide = true;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        UIManager.Instance.AddUIButton(id, button);
        if (hide) gameObject.gameObject.SetActive(false);
    }
}
