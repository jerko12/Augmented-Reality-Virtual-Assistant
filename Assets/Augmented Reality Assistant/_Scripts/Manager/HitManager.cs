using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;

public class HitManager : Singleton<HitManager>
{
    public UnityEvent<Vector3> onGroundHit;
    public UnityEvent<Vector3> onAvatarHit;


    public void GroundChecker(ARRaycastHit arHit, RaycastHit hit)
    {
        
        onGroundHit?.Invoke(arHit.pose.position);
    }

}
