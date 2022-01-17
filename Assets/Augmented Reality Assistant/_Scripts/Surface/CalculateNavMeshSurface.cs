using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class CalculateNavMeshSurface : MonoBehaviour
{
    [SerializeField]private NavMeshSurface surface;
    public bool running = true;

    [SerializeField] private int updateTime = 250;

    private void Awake()
    {
        if(surface == null) { GetComponent<NavMeshSurface>(); }
    }

    // Start is called before the first frame update
    void Start()
    {
        Run();
    }

    async void Run()
    {
        while (running)
        {
            await CalculateNavMesh();
        }
    }

    async Task CalculateNavMesh()
    {
        surface.BuildNavMesh();
        await Task.Delay(updateTime);
    }
}
