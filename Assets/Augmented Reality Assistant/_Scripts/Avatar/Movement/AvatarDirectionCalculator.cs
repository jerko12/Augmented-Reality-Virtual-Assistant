using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AvatarDirectionCalculator : MonoBehaviour
{

    public UnityEvent<Vector3> onDirectionUpdated;
    private Vector3 previousLocation = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        previousLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.deltaTime != 0)
        {
            //previous
            Vector3 velocity = (transform.position - previousLocation)/Time.deltaTime;
            onDirectionUpdated?.Invoke(velocity);
            previousLocation = transform.position;
        }
    }
}
