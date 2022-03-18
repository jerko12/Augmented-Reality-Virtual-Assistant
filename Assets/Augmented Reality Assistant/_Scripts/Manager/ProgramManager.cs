using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ProgramManager : Singleton<ProgramManager>
{
    public enum programState
    {
        startup,
        normal,
        avatar_place,
        avatar_speech,
        ui_option_select,
        ui_radial_menu
    }

    public programState currentState = programState.normal;

    public NormalProgramState normal;
    public AvatarPlaceProgramState avatar_place;
    public AvatarSpeechState avatar_speech;

    #region state Actions
    public void SwitchState(programState newState)
    {
        if (currentState != newState)
        {
            ExitState(currentState);
            currentState = newState;
            EnterState(currentState);
        }
    }

    public void EnterState(programState state)
    {
        switch (currentState)
        {
            case programState.normal: normal.enter();break;
            case programState.avatar_place: avatar_place.enter();break;
            case programState.avatar_speech:avatar_speech.enter();break;
            case programState.ui_radial_menu:;break;
        }
    }

    public void ExitState(programState state)
    {
        switch (currentState)
        {
            case programState.normal: normal.exit(); break;
            case programState.avatar_place: avatar_place.exit(); break;
            case programState.avatar_speech: avatar_speech.enter(); break;
            case programState.ui_radial_menu:; break;
        }
    }

    public void setNormal()
    {
        SwitchState(programState.normal);
    }

    public void setAvatarPlaceState(Avatar _currentAvatar)
    {
        avatar_place.currentAvatarToPlace = _currentAvatar;
        SwitchState(programState.avatar_place);
    }

    public void setAvatarSpeechState()
    {
        SwitchState(programState.avatar_speech);
    }

    public void setOptionSelectState()
    {

    }
    #endregion
    public override void Awake()
    {
        base.Awake();

        normal.awake();
        avatar_place.awake();
        avatar_speech.awake();
    }

    private void Start()
    {
        normal.start();
        avatar_place.start();
        avatar_speech.start();

        RaycastManager.Instance.onRaycastHit.AddListener(OnRaycastHit);
        RaycastManager.Instance.onGroundRaycasthit.AddListener(OnGroundRaycastHit);
        RaycastManager.Instance.onAvatarRaycasthit.AddListener(OnAvatarRaycastHit);
        RaycastManager.Instance.onInteractableRaycasthit.AddListener(OnInteractableRaycastHit);

        InputManager.Instance.onPrimaryPressStarted.AddListener(OnTouchStarted);
        InputManager.Instance.onPrimaryLocationChanged.AddListener(OnTouchUpdated);
        InputManager.Instance.onPrimaryPressEnded.AddListener(OnTouchEnded);

        UIManager.Instance.AcceptButton.onClick.AddListener(OnAcceptButton);
        UIManager.Instance.DenyButton.onClick.AddListener(OnDenyButton);

        EnterState(currentState);
    }

    private void Update()
    {
        switch (currentState)
        {
            case programState.normal: normal.update(); break;
            case programState.avatar_place: avatar_place.update(); break;
            case programState.avatar_speech: avatar_speech.update(); break;
            case programState.ui_radial_menu:; break;
        }
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case programState.normal: normal.fixed_update(); break;
            case programState.avatar_place: avatar_place.fixed_update(); break;
            case programState.avatar_speech:avatar_speech.fixed_update(); break;
            case programState.ui_radial_menu:; break;
        }
    }

    private void LateUpdate()
    {
        switch (currentState)
        {
            case programState.normal: normal.late_update(); break;
            case programState.avatar_place: avatar_place.late_update(); break;
            case programState.avatar_speech: avatar_speech.late_update(); break;
            case programState.ui_radial_menu:; break;
        }
    }



    public void OnRaycastHit(RaycastHit _hit)
    {
        switch (currentState)
        {
            case programState.normal: normal.OnRayHit(_hit); break;
            case programState.avatar_place: avatar_place.OnRayHit(_hit); break;
            case programState.avatar_speech: avatar_speech.OnRayHit(_hit); break;
            case programState.ui_radial_menu:; break;
        }
    }
    public void OnGroundRaycastHit(RaycastHit _hit)
    {
        switch (currentState)
        {
            case programState.normal: normal.OnGroundRayHit(_hit); break;
            case programState.avatar_place: avatar_place.OnGroundRayHit(_hit); break;
            case programState.avatar_speech:avatar_speech.OnGroundRayHit(_hit); break;
            case programState.ui_radial_menu:; break;
        }
    }
    public void OnAvatarRaycastHit(RaycastHit _hit)
    {
        switch (currentState)
        {
            case programState.normal: normal.OnAvatarRayHit(_hit); break;
            case programState.avatar_place: avatar_place.OnAvatarRayHit(_hit); break;
            case programState.avatar_speech:avatar_speech.OnAvatarRayHit(_hit); break;
            case programState.ui_radial_menu:; break;
        }
    }
    public void OnInteractableRaycastHit(RaycastHit _hit)
    {
        switch (currentState)
        {
            case programState.normal: normal.OnInteractableRayHit(_hit); break;
            case programState.avatar_place: avatar_place.OnInteractableRayHit(_hit); break;
            case programState.avatar_speech:avatar_speech.OnInteractableRayHit(_hit); break;
            case programState.ui_radial_menu:; break;
        }
    }

    public void OnTouchStarted(Vector2 _touchPos)
    {
        switch (currentState)
        {
            case programState.normal: normal.onTouchStarted(_touchPos); break;
            case programState.avatar_place: avatar_place.onTouchStarted(_touchPos); break;
            case programState.avatar_speech:avatar_speech.onTouchStarted(_touchPos); break;
            case programState.ui_radial_menu:; break;
        }
    }

    public void OnTouchUpdated(Vector2 _touchPos)
    {
        switch (currentState)
        {
            case programState.normal: normal.onTouchUpdated(_touchPos); break;
            case programState.avatar_place: avatar_place.onTouchUpdated(_touchPos); break;
            case programState.avatar_speech: avatar_speech.onTouchUpdated(_touchPos); break;
            case programState.ui_radial_menu:; break;
        }
    }

    public void OnTouchEnded(Vector2 _touchPos)
    {
        switch (currentState)
        {
            case programState.normal: normal.onTouchEnded(_touchPos); break;
            case programState.avatar_place: avatar_place.onTouchEnded(_touchPos); break;
            case programState.avatar_speech: avatar_speech.onTouchEnded(_touchPos); break;
            case programState.ui_radial_menu:; break;
        }
    }

    public void OnAcceptButton()
    {
        switch (currentState)
        {
            case programState.normal:normal.OnAcceptButtonPress();break;
            case programState.avatar_place: avatar_place.OnAcceptButtonPress();break;
            case programState.avatar_speech: avatar_speech.OnAcceptButtonPress();break;
        }
    }

    public void OnDenyButton()
    {
        switch (currentState)
        {
            case programState.normal: normal.OnDenyButtonPress();break;
            case programState.avatar_place: avatar_place.OnDenyButtonPress();break;
            case programState.avatar_speech: avatar_speech.OnDenyButtonPress();break;
        }
    }
}
