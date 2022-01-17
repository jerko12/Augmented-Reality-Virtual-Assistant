using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PointerUI : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    private void Start()
    {
        RaycastManager.Instance.onARRaycastHit.AddListener(onNewRaycastHit);
    }
    public void onNewRaycastHit(ARRaycastHit arHit,RaycastHit hit)
    {
        canvas.transform.position = arHit.pose.position;
        canvas.transform.forward = arHit.pose.up;
    }
}
