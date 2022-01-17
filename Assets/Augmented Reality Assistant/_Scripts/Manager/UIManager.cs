using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UI_RadialMenu RadialMenu;
    [SerializeField] private MenuOption SetAvatarPositionOption;
    [SerializeField] private MenuOption DebugOption;
    [SerializeField] private MenuOption Debug2Option;


    private static UIManager _instance;

    public static UIManager Instance { get { return _instance; } }
    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
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
