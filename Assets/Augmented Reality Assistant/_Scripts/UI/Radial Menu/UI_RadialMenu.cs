using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_RadialMenu : MonoBehaviour
{
    [SerializeField] private GameObject UI_RadialTextPart;

    [SerializeField] private float distance = 1;
    [SerializeField] private List<MenuOption> menuOptions;

    //public Dictionary<Vector2, MenuOption> UI_MenuOptions = new Dictionary<Vector2, MenuOption>();

    private Vector2 startLocation;
    private Vector3 worldPosition;

    private void Start()
    {
        SetOptions();
        //HitManager.Instance.onGroundHit.AddListener(StartMenu);
        

    }


    /// <summary>
    /// Set the different options of the radial menu.
    /// </summary>
    private void SetOptions()
    {
        int index = 0;
        foreach (MenuOption radialMenuOption in menuOptions)
        {
            GameObject currentMenuOptionUI;
            Vector2 currentDirection;

            (currentMenuOptionUI, currentDirection) = placeMenuOption(index, menuOptions.Count);
            radialMenuOption.UI = currentMenuOptionUI;
            index++;
            TMP_Text text = currentMenuOptionUI.GetComponentInChildren<TMP_Text>();
            Image image = currentMenuOptionUI.GetComponentInChildren<Image>();
            text.text = radialMenuOption.name;
            image.sprite = radialMenuOption.image;
            image.color = radialMenuOption.color;
        }
    }

    /// <summary>
    /// Set the radial menu's position to the screen press location and show the UI.
    /// </summary>
    /// <param name="screenPosition">The press position on the screen.</param>
    public void StartMenu(Vector3 _worldPosition)
    {
        startLocation = InputManager.Instance.startPrimaryTouchPos;
        worldPosition = _worldPosition;

        transform.position = new Vector3(startLocation.x, startLocation.y, 0);// Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x,screenPosition.y,10));

        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

        InputManager.Instance.onPrimaryLocationChanged.AddListener(CheckInputDirection);
        InputManager.Instance.onPrimaryPressEnded.AddListener(EndMenu);
    }


    /// <summary>
    /// Run the selected action's event and hide the radial menu's UI.
    /// </summary>
    /// <param name="screenPosition">The press position on the screen.</param>
    public void EndMenu(Vector2 screenPosition)
    {
        Vector2 direction = screenPosition - startLocation;
        MenuOption selectedOption = GetMenuOptionInDirection(direction.normalized);
        selectedOption.onRun?.Invoke(worldPosition);


        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        InputManager.Instance.onPrimaryLocationChanged.RemoveListener(CheckInputDirection);
        InputManager.Instance.onPrimaryPressEnded.RemoveListener(EndMenu);
    }

    /// <summary>
    /// Place the UI radially 
    /// </summary>
    /// <param name="index"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    private (GameObject, Vector3) placeMenuOption(int index, int count)
    {
        GameObject currentMenuOption = Instantiate(UI_RadialTextPart, transform);
        Vector3 angledDirection = Quaternion.Euler(0, 0, -(360 / count) * index) * Vector3.up;
        currentMenuOption.transform.localPosition = Vector3.zero + angledDirection.normalized * distance;
        return (currentMenuOption, angledDirection.normalized * distance);
    }

    /// <summary>
    /// check the input direction and visualize which option is selected.
    /// </summary>
    /// <param name="direction"></param>
    public void CheckInputDirection(Vector2 direction)
    {
        //Vector2 currentDirection = GetClosestDirection(GetDirections(menuOptions.Count),direction);
        Vector2 currentDirection = direction - startLocation;
        int index = GetClosestIndex(GetDirections(menuOptions.Count), currentDirection);
        MenuOption currentMenuOption = menuOptions[index];  //UI_MenuOptions[currentDirection.normalized];
        Debug.Log(currentMenuOption.name + " - " + currentDirection);
    }

    /// <summary>
    /// check which option is selected and perform its event.
    /// </summary>
    /// <param name="direction"></param>
    public MenuOption GetMenuOptionInDirection(Vector2 direction)
    {
        int index = GetClosestIndex(GetDirections(menuOptions.Count), direction);
        return menuOptions[index]; 
    }

    /// <summary>
    /// Get all the possible radial directions for a certain count.
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    private Vector2[] GetDirections(int count)
    {
        Vector2[] directions = new Vector2[count];
        for (int index = 0; index < count; index++)
        {
            directions[index] = Quaternion.Euler(0, 0, -(360 / count) * index) * Vector3.up;
        }
        return directions;
    }

    /// <summary>
    /// Get to closest menuOption direction to a current direction
    /// </summary>
    /// <param name="directions">all possible menuOption directions</param>
    /// <param name="currentDirection">current input direction</param>
    /// <returns></returns>
    private Vector2 GetClosestDirection(Vector2[] directions,Vector2 currentDirection)
    {
        float currentAngle = Vector2.Angle(directions[0], currentDirection);
        Vector2 closestDirection = directions[0];
        foreach(Vector2 direction in directions)
        {
            float newAngle = Vector2.Angle(direction, currentDirection);
            if(currentAngle > newAngle)
            {
                currentAngle = newAngle;
                closestDirection = direction;
            }
        }
        return closestDirection;
    }

    /// <summary>
    /// Get the index of the closest direction to the given direction from a list of all possible directions.
    /// </summary>
    /// <param name="possibleDirections">All possible directions</param>
    /// <param name="direction">The given direction</param>
    /// <returns>Return the index of the closest direction in the list</returns>
    public int GetClosestIndex(Vector2[] possibleDirections, Vector2 direction)
    {
        float currentAngle = Vector2.Angle(possibleDirections[0], direction);
        int index = 0;
        for (int i = 0; i < possibleDirections.Length; i++)
        {
            float newAngle = Vector2.Angle(possibleDirections[i], direction);
            if(currentAngle> newAngle)
            {
                currentAngle = newAngle;
                index = i;
            }
        }
        return index;
    }
}
