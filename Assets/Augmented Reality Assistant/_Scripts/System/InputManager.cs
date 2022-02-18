using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.EventSystems;

public class InputManager : Singleton<InputManager>
{
    InputControls input;
    public Vector2 startPrimaryTouchPos;
    public Vector2 currentTouchPos;
    public bool isPrimaryPressed = false;


    // Normal
    [Header("Primary Touch Events")]
    public UnityEvent<Vector2> onPrimaryPressStarted;   
    public UnityEvent<Vector2> onPrimaryLocationChanged;
    public UnityEvent<Vector2> onPrimaryPressEnded;
    

    public override void Awake()
    {
        base.Awake();
        input = new InputControls();

    }

    private void OnEnable()
    {
        input.ARInput.PrimaryTouch.performed += ctx => PrimaryTouchStart() ;
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
        
        if (EventSystem.current.IsPointerOverGameObject()) return;
        startPrimaryTouchPos = input.ARInput.PrimaryTouchPosition.ReadValue<Vector2>();
        onPrimaryPressStarted?.Invoke(startPrimaryTouchPos);
        isPrimaryPressed = true;

        Debug.Log("Is Over UI " + EventSystem.current.IsPointerOverGameObject());
    }

    private void PrimaryTouchUpdate()
    {
        //Time.frameCount % 100 == 0
        if (!isPrimaryPressed) return;
        currentTouchPos = input.ARInput.PrimaryTouchPosition.ReadValue<Vector2>();
        onPrimaryLocationChanged?.Invoke(currentTouchPos);
        //if (!isPrimaryPressed) return;
        
        
    }
    
    private void PrimaryTouchEnd()
    {
        if (!isPrimaryPressed) return;
        //if (EventSystem.current.IsPointerOverGameObject()) return;
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
