using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// IK Target used for Inverse Kinematics
/// </summary>
public class IKTarget : MonoBehaviour
{

    public Transform target;
    public Vector3 offset = Vector3.zero;
    public float speed = 4;

    /// <summary>
    /// set the target of the IK target
    /// </summary>
    /// <param name="target"></param>
    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    /// <summary>
    /// set the offset from the target the IK Target will be placed.
    /// </summary>
    /// <param name="offset"></param>
    public void SetOffset(Vector3 offset)
    {
        this.offset = offset;
    }

    /// <summary>
    /// set the movement speed the IK Target moves to it's target
    /// </summary>
    /// <param name="speed"></param>
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    private void LateUpdate()
    {
        if (!target) return;

        transform.position = Vector3.Lerp(transform.position,target.position + offset,Time.deltaTime *speed);
    }
}
