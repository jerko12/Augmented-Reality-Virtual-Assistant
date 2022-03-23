using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private UI_RadialMenu RadialMenu;
    [SerializeField] private MenuOption SetAvatarPositionOption;

    public UnityEvent onShowToolbar;

    public Dictionary<string, UI_Element> UIelements = new Dictionary<string, UI_Element>();
    public Dictionary<string, Button> UIButtons = new Dictionary<string, Button>();

    //[SerializeField] private MenuOption DebugOption;
    //[SerializeField] private MenuOption Debug2Option;
    [Header("Main Menu Buttons")]
    public Button Menu;

    [Header("Action Buttons")]
    public Button AcceptButton;
    public Button DenyButton;
    public Button NextButton;

    public Button action1Button;
    public Button action2Button;
    public Button action3Button;
    public Button action4Button;
    public Button action5Button;


    public override void Awake()
    {
        base.Awake();
    }

    public void showAcceptButton()
    {
        AcceptButton.gameObject.SetActive(true);
    } 
    
    public void showDenyButton()
    {
        DenyButton.gameObject.SetActive(true);
    }

    public void hideButtons()
    {
        AcceptButton.gameObject.SetActive(false);
        DenyButton.gameObject.SetActive(false);
    }

    public void showActionButton1(bool doShow)
    {
        action1Button.gameObject.SetActive(doShow);
    }
    public void showActionButton2(bool doShow)
    {
        action2Button.gameObject.SetActive(doShow);
    }



    public void UpdateFloorActionRadialMenu(Vector2 screenPosition)
    {

    }

    public void SpawnAvatarAction()
    {

    }

    public void DebugAction()
    {

    }


    public void AddUIElement(string name, UI_Element element)
    {
        UIelements.Add(name, element);
    }

    public void AddUIButton(string name, Button button)
    {
        UIButtons.Add(name, button);
    }

    public UI_Element GetUIElement(string name)
    {
        if (!UIelements.ContainsKey(name)) return null;
        return UIelements[name];
    }

    public Button GetButton(string id)
    {
        if (!UIButtons.ContainsKey(id)) return null;
        return UIButtons[id];
    }
}

/// <summary>
/// A menu option with a name,image, an event and the connected GameObject. (The GameObject is set on runtime when the UI gameObject is instantiated).
/// </summary>
[System.Serializable]
public class MenuOption
{
    public string name = "";
    public Sprite image;
    public Color color;
    public UnityEvent<Vector3> onRun;
    public GameObject UI;

    public MenuOption(string _name, Sprite _image)
    {
        name = _name;
        image = _image;
    }
}
