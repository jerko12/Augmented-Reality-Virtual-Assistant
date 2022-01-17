using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class AvatarWalkAround : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]private int TargetUpdateTime = 2500;
    [SerializeField] private float radius = 2;

    private Vector3 StartLocation;
    bool isRunning = true;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        StartLocation = transform.position;

        if (agent.isOnNavMesh)
        {
            Run();
        }
        else
        {
            WaitForNavMesh();
        }
    }

    async void WaitForNavMesh()
    {
        while (!agent.isOnNavMesh)
        {
            Debug.Log("No Navmesh On Agent!");
            await Task.Delay(1000);
        }

        Run();
    }


    async void Run()
    {
        while (isRunning)
        {
            await SetNewTarget();
        }
    }

    async Task SetNewTarget()
    {
        Vector2 pointInCircle = Random.insideUnitCircle * radius;
        Vector3 pointInCircle3D = new Vector3(pointInCircle.x, 0, pointInCircle.y) + StartLocation;
        agent.SetDestination(pointInCircle3D);
        await Task.Delay(TargetUpdateTime);
    }
}
