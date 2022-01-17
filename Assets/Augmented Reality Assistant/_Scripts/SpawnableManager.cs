using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnableManager : Singleton<SpawnableManager>
{

    [SerializeField] ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    [SerializeField] GameObject spawnablePrefab;
    Camera arCam;
    GameObject spawnedAvatar;

    // Start is called before the first frame update
    void Start()
    {
        //InputManager.Instance.onPrimaryPressStarted.AddListener(AtTouchStart);
        //InputManager.Instance.onPrimaryLocationChanged.AddListener(AtTouchPositionChanged);
        //InputManager.Instance.onPrimaryPressEnded.AddListener(AtTouchEnded);

        RaycastManager.Instance.onARRaycastHit.AddListener(AtArRaycastHit);

        spawnedAvatar = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
    }

    public void AtArRaycastHit(ARRaycastHit arHit,RaycastHit hit)
    {

        Debug.Log("DoSpawn");
        if (spawnedAvatar == null) {
            Spawn(arHit, hit);
        }
        else if (hit.transform.CompareTag("Avatar"))
        {
            AvatarManager.Instance.InteractWithAvatar();
        }

        else
        {
            //SetDestination(arHit);
        }
    }

    public void Spawn(ARRaycastHit arHit, RaycastHit hit)
    {
        if (hit.collider.gameObject.tag == "Spawnable")
        {
            spawnedAvatar = hit.collider.gameObject;
            Vector3 lookPos = Camera.main.transform.position;
            spawnablePrefab.transform.LookAt(new Vector3(lookPos.x, lookPos.z));
        }
        else if(hit.collider.gameObject.tag == "GameController")
        {
            AvatarManager.Instance.InteractWithAvatar();
        }
        else
        {
            SpawnPrefab(arHit.pose.position);
        }
    }

    public void SetDestination(ARRaycastHit arHit)
    {
        AvatarManager.Instance.SetAvatarDestination(arHit.pose.position);
    }

    public void AtTouchPositionChanged(Vector2 touchLocation)
    {
        Debug.Log("UpdateTouch | " + touchLocation);
        m_Hits = getRaycastHits(touchLocation);
        if (m_Hits != null && spawnedAvatar != null)
        {
            //spawnedAvatar.transform.position = m_Hits[0].pose.position;
        }
    }

    public void AtTouchEnded()
    {
        Debug.Log("Ended");
        //spawnedAvatar = null;
    }

    private List<ARRaycastHit> getRaycastHits(Vector2 pos)
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (m_RaycastManager.Raycast(pos, hits))
        {
            return hits;
        }
        return null;
    }

    
    private void SpawnPrefab(Vector3 spawnPosition)
    {
        spawnedAvatar = Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity);

    }
}