using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosRotatoinAngleViewer : MonoBehaviour
{

    [SerializeField] GameObject rotator;

    [SerializeField] GameObject UpperLeft;// UpperLeft
    [SerializeField] GameObject UpperRight;// UpperRight
    [SerializeField] GameObject LowerLeft;// LowerLeft


    private void OnDrawGizmos()
    {
        
        // The positions in world space which are seen by the camera
        Vector3 position1 = UpperLeft.transform.position;// UpperLeft
        Vector3 position2 = UpperRight.transform.position;// UpperRight
        Vector3 position3 = LowerLeft.transform.position;// LowerLeft

        Gizmos.DrawSphere(position1, .1f);
        Gizmos.DrawSphere(position2, .1f);
        Gizmos.DrawSphere(position3, .1f);

        // Calculate the normal of the plane and apply this normal to the upper direction of the table plane.
        Vector3 normal = Vector3.Cross(position2 - position1, position3 - position1);
        rotator.transform.up = normal;

        // project upperleft and lowerleft to the normal plane.
        Vector3 pos1Projected = Vector3.ProjectOnPlane(position1, normal);
        Vector3 pos3Projected = Vector3.ProjectOnPlane(position3, normal);

        // Local position is the same as offset --- REWRITE THIS!
        Vector2 pos1Local = new Vector2(UpperLeft.transform.localPosition.x * UpperLeft.transform.parent.localScale.x, UpperLeft.transform.localPosition.z * UpperLeft.transform.parent.localScale.z); 
        Vector2 pos3Local = new Vector2(LowerLeft.transform.localPosition.x * LowerLeft.transform.parent.localScale.x, LowerLeft.transform.localPosition.z * LowerLeft.transform.parent.localScale.z);

        // calculate the offset angle
        float offsetAngle = GetAngle(pos1Local, pos3Local, Vector2.down, -Vector2.right);

        // calculate the direction of forward direction of the plane.
        Vector3 directionForward = GetDirection(pos1Projected, pos3Projected).normalized;
        // set the plane rotatioon to the forward direction and upward(normal) direction.
        rotator.transform.rotation = Quaternion.LookRotation(directionForward,normal);
        
        // Rotate the object in the offset.
        rotator.transform.Rotate(Vector3.up, 180 + offsetAngle);

    }
    /// <summary>
    /// Calculate the direction between 2 points.
    /// </summary>
    /// <param name="pointA">Point From</param>
    /// <param name="pointB">Point To</param>
    /// <returns></returns>
    public Vector3 GetDirection(Vector3 pointA,Vector3 pointB)
    {
        return (pointB - pointA).normalized;
    }

    /// <summary>
    /// Calculate the angle between 2 points
    /// </summary>
    /// <param name="positionA">Position A</param>
    /// <param name="positionB">Position B</param>
    /// <param name="fromDirection"> Direction to calculate angle from.</param>
    /// <param name="dotDirection">the direction used to calculate if the angle is left or right from the fromDirection.</param>
    /// <returns></returns>
    public float GetAngle(Vector2 positionA, Vector2 positionB, Vector2 fromDirection,Vector2 dotDirection)
    {
        Vector2 direction = positionB - positionA;
        float angle = Vector2.Angle(fromDirection,direction);
        float dot = Vector2.Dot(direction,-dotDirection);
        if (dot < 0) angle = -angle;
        return angle;
    }
}
