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

    [Header("Normal Raycast")]
    public UnityEvent<RaycastHit> onGroundRaycasthit;
    public UnityEvent<RaycastHit> onAvatarRaycasthit;
    public UnityEvent<RaycastHit> onInteractableRaycasthit;
    [Space]
    [Header("Raycast Settings")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask avatarLayer;
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] float raycastDistance = 50;
    [Space]

    public ARRaycastHit arHit;
    public RaycastHit worldHit;

    public enum hitType
    {
        air,
        ground,
        avatar,
        interactable
    }

    

    private void Start()
    {
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
        arCam = Camera.main;
        InputManager.Instance.onPrimaryLocationChanged.AddListener(Raycast);
        //InputManager.Instance.onPrimaryLocationChanged.AddListener();
        //InputManager.Instance.onPrimaryPressEnded.AddListener();
        
    }

    public void Raycast(Vector2 touchPositionScreen)
    {
        Ray ray = RaycastFromScreenPoint(touchPositionScreen);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastDistance,interactableLayer))
        {
            onInteractableRaycasthit?.Invoke(hit);
        }
        if(Physics.Raycast(ray, out hit, raycastDistance, avatarLayer)){
            onAvatarRaycasthit?.Invoke(hit);
        }
        if(Physics.Raycast(ray,out hit, raycastDistance, groundLayer))
        {
            onGroundRaycasthit?.Invoke(hit);
        }
    }

    public Ray RaycastFromScreenPoint(Vector2 touchScreenPosition)
    {
        return arCam.ScreenPointToRay(touchScreenPosition);
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
    public List<ARRaycastHit> getARHits(Vector2 pos)
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
