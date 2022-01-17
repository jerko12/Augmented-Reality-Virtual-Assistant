using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class InputSystem : PersistentSingleton<InputSystem>
{
    InputControls input;
    public Vector2 startPrimaryTouchPos;
    public Vector2 currentTouchPos;
    public bool isPrimaryPressed = false;

    public UnityEvent<Vector2> onPrimaryPressStarted;   
    public UnityEvent<Vector2> onPrimaryLocationChanged;
    public UnityEvent<Vector2> onPrimaryPressEnded;
    
    private void Awake()
    {
        input = new InputControls();

    }

    private void OnEnable()
    {
        input.ARInput.PrimaryTouch.performed += ctx => PrimaryTouchStart();
        input.ARInput.PrimaryTouch.canceled += ctx => PrimaryTouchEnd();

        input.ARInput.PrimaryTouchPosition.performed += ctx => PrimaryTouchUpdate();

        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void PrimaryTouchStart()
    {
        startPrimaryTouchPos = input.ARInput.PrimaryTouchPosition.ReadValue<Vector2>();
        onPrimaryPressStarted?.Invoke(startPrimaryTouchPos);
        isPrimaryPressed = true;
    }

    private void PrimaryTouchUpdate()
    {
        //if (!isPrimaryPressed) return;
        currentTouchPos = input.ARInput.PrimaryTouchPosition.ReadValue<Vector2>();
        onPrimaryLocationChanged?.Invoke(currentTouchPos);
    }
    
    private void PrimaryTouchEnd()
    {
        currentTouchPos = input.ARInput.PrimaryTouchPosition.ReadValue<Vector2>();
        onPrimaryPressEnded?.Invoke(currentTouchPos);
        isPrimaryPressed = false;
    }

    static public void LogDit()
    {
        Debug.Log("Er is geklikt");
    }
    
    static public void LogDat(Vector2 position)
    {
        Debug.Log("Er is bewogen naar " + position);
    }
}
