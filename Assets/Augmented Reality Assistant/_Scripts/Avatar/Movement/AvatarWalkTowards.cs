using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AvatarWalkTowards : MonoBehaviour
{
    NavMeshAgent agent;
    private void Awake()
    {
       
        
    }
    private void Start()
    {
        AvatarManager.Instance.selectedAvatar = this.gameObject;
        agent = GetComponent<NavMeshAgent>();
        SetDestination(new Vector3(5, 0, 1));
    }


    public void SetDestination(Vector3 destination)
    {
        if (agent == null) return;
        if (agent.isOnNavMesh == false) return;

        agent.SetDestination(destination);
    }
}
