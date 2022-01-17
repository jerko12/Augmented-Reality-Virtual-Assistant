using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;

public class RaycastManager : Singleton<RaycastManager>
{
    [SerializeField] ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    Camera arCam;
    RaycastHit hit;
    

    public UnityEvent<ARRaycastHit,RaycastHit> onARRaycastHit;
    public UnityEvent<RaycastHit> onRaycastHit;
    public UnityEvent<ARRaycastHit> onARHit;

    public ARRaycastHit arHit;
    public RaycastHit worldHit;

    public enum hitType
    {
        air,
        ground,
        avatar
    }

    private void Awake()
    {

    }

    private void Start()
    {
        InputSystem.Instance.onPrimaryPressStarted.AddListener(ARRaycastFromScreenPoint);
        //InputManager.Instance.onPrimaryLocationChanged.AddListener();
        //InputManager.Instance.onPrimaryPressEnded.AddListener();
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    public void RaycastFromScreenPoint(Vector2 touchScreenPosition)
    {
        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);
    }

    public void ARRaycastFromScreenPoint(Vector2 touchScreenPosition)
    {
        m_Hits = getARHits(touchScreenPosition);
        RaycastHit hit = new RaycastHit();
        bool hasHit = checkHit(ref hit, touchScreenPosition);
        
        if (m_Hits != null)
        {
            onARHit?.Invoke(m_Hits[m_Hits.Count-1]);
            arHit = m_Hits[0];
            if (hasHit)
            {
                onARRaycastHit?.Invoke(m_Hits[m_Hits.Count - 1], hit);
                worldHit = hit;
            } 
        }
    }
    private List<ARRaycastHit> getARHits(Vector2 pos)
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (m_RaycastManager.Raycast(pos, hits))
        {
            return hits;
        }
        return null;
    }

    public bool checkHit(ref RaycastHit hit, Vector2 pos)
    {
        Ray ray = arCam.ScreenPointToRay(pos);
        if (Physics.Raycast(ray, out hit))
        {
            onRaycastHit?.Invoke(hit);
            return true;
        }
        return false;
    }

    public hitType getHitType()
    {
        hitType currentHitType = hitType.air;

        return currentHitType;
    }
}
