using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;

public class AvatarPlaceProgramState : ProgramState
{
    public UnityEvent<Vector3> onAvatarPlacementLocationUpdated;
    public Avatar currentAvatarToPlace;


    public override void enter()
    {
        base.enter();
        currentAvatarToPlace.gameObject.SetActive(true);
        UIManager.Instance.showAcceptButton();
        Debug.Log("Avatar Place State - enter");
    }

    public override void exit()
    {
        currentAvatarToPlace.onAvatarPlaced?.Invoke();
        base.exit();
        UIManager.Instance.hideButtons();
        Debug.Log("Avatar Place State - exit");
    }

    public override void onTouchUpdated(Vector2 _touchPos)
    {
        base.onTouchUpdated(_touchPos);
       // List<ARRaycastHit> arHits = RaycastManager.Instance.getARHits(_touchPos);
        //if (arHits == null || arHits.Count == 0) return;
        //onAvatarPlacementLocationUpdated?.Invoke(arHits[0].pose.position);
        //RaycastHit hit = RaycastManager.Instance.worldHit
    }


    public override void OnGroundRayHit(RaycastHit _hit)
    {
        if (currentAvatarToPlace == null) return;

        currentAvatarToPlace.transform.position = _hit.point;

        Vector3 lookAtLocation = new Vector3(Camera.main.transform.position.x, currentAvatarToPlace.transform.position.y, Camera.main.transform.position.z);
        currentAvatarToPlace.transform.LookAt(lookAtLocation);

        base.OnGroundRayHit(_hit);
    }

    public override void OnAcceptButtonPress()
    {
        base.OnAcceptButtonPress();
        currentAvatarToPlace.start();
        AvatarManager.Instance.NextQueue();
        Debug.Log("Accept this location");
    }
}
