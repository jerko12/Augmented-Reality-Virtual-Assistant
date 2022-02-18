using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// A state the program can be in.
/// </summary>
public class ProgramState : MonoBehaviour
{
    #region Events
    //State Events
    [Header("State Events")]
    public UnityEvent onStateEnter;
    public UnityEvent onStateExit;

    //Input Events
    [Header("Input Events")]
    public UnityEvent<RaycastHit> onRaycastHit;
    public UnityEvent<RaycastHit> onGroundRaycastHit;
    public UnityEvent<RaycastHit> onAvatarRaycastHit;
    public UnityEvent<RaycastHit> onInteractableRaycastHit;
    public UnityEvent<Vector2> onTouchEnter;
    public UnityEvent<Vector2> onTouchUpdate;
    public UnityEvent<Vector2> onTouchExit;

    //User Interface
    [Header("User Interface Events")]
    public UnityEvent onAcceptButtonPressed;
    public UnityEvent onDenyButtonPressed;
    #endregion

    #region state
    /// <summary>
    /// Run every time the state is entered
    /// </summary>
    public virtual void enter() { onStateEnter?.Invoke(); }
    /// <summary>
    /// Runs every time the state is exited
    /// </summary>
    public virtual void exit() { onStateExit?.Invoke(); }
    #endregion

    #region monoBehaviour
    /// <summary>
    /// Runs on awake
    /// </summary>
    public virtual void awake() { }
    /// <summary>
    /// Runs on start
    /// </summary>
    public virtual void start() { }
    /// <summary>
    /// Runs on update
    /// </summary>
    public virtual void update() { }
    /// <summary>
    /// Run on fixed update
    /// </summary>
    public virtual void fixed_update() { }
    /// <summary>
    /// runs on late update
    /// </summary>
    public virtual void late_update() { }
    #endregion

    #region input
    /// <summary>
    /// Runs when a raycast is performed.
    /// </summary>
    /// <param name="_arHit">The AR raycast hit</param>
    /// <param name="_hit">The normal raycast hit</param>
    public virtual void OnRayHit(RaycastHit _hit) { onRaycastHit?.Invoke(_hit); }
    /// <summary>
    /// Runs when a raycast is performed.
    /// </summary>
    /// <param name="_arHit">The AR raycast hit</param>
    /// <param name="_hit">The normal raycast hit</param>
    public virtual void OnGroundRayHit(RaycastHit _hit) { onGroundRaycastHit?.Invoke(_hit); }
    /// <summary>
    /// Runs when a raycast is performed.
    /// </summary>
    /// <param name="_arHit">The AR raycast hit</param>
    /// <param name="_hit">The normal raycast hit</param>
    public virtual void OnAvatarRayHit(RaycastHit _hit) { onAvatarRaycastHit?.Invoke(_hit); }
    /// <summary>
    /// Runs when a raycast is performed.
    /// </summary>
    /// <param name="_arHit">The AR raycast hit</param>
    /// <param name="_hit">The normal raycast hit</param>
    public virtual void OnInteractableRayHit(RaycastHit _hit) { onInteractableRaycastHit?.Invoke(_hit); }
    /// <summary>
    /// Runs when the main touch is started
    /// </summary>
    /// <param name="_touchPos">The touch position on the screen</param>
    public virtual void onTouchStarted(Vector2 _touchPos) { onTouchEnter?.Invoke(_touchPos); }
    /// <summary>
    /// Runs when the touch position is updated
    /// </summary>
    /// <param name="_touchPos">The touch position on the screen</param>
    public virtual void onTouchUpdated(Vector2 _touchPos) { onTouchUpdate?.Invoke(_touchPos); }
    /// <summary>
    /// Run when the main touch is ended
    /// </summary>
    /// <param name="_touchPos">The touch position on the screen</param>
    public virtual void onTouchEnded(Vector2 _touchPos) { onTouchExit?.Invoke(_touchPos); }
    #endregion

    #region user interface
    public virtual void OnAcceptButtonPress() { onAcceptButtonPressed?.Invoke(); }
    public virtual void OnDenyButtonPress() { onDenyButtonPressed?.Invoke(); }
    #endregion
}
