using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AvatarIK : MonoBehaviour
{
    [SerializeField] private MultiAimConstraintGroup headIK = new MultiAimConstraintGroup();
    [SerializeField] private GameObject avatar;
    [SerializeField] private Vector3 offset;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //WeightedTransformArray currentSources = headIK.MultiAimConstraints[0].data.sourceObjects;
        Vector3 direction = ( cam.transform.position - (avatar.transform.position + offset)).normalized;
        float angle = Vector3.Angle(avatar.transform.forward, direction);
        
        if(angle < headIK.minAngle)
        {
            SetHeadIKWeight(headIK,1);
        }
        else
        {
            Debug.Log("Angle: " + (angle - headIK.maxAngle));
            SetHeadIKWeight(headIK,getSmoothWeight(angle,headIK.minAngle,headIK.maxAngle));
        }
    }

    public float getSmoothWeight(float currentAngle,float minAngle,float maxAngle)
    {
        return Mathf.Clamp(1 -(currentAngle- minAngle)/(maxAngle-minAngle),0,1);
    }

    public void SetHeadIKWeight(MultiAimConstraintGroup aimContrainGroup,float weight)
    {
        foreach(MultiAimConstraint aimConstrain in aimContrainGroup.MultiAimConstraints)
        {
            aimConstrain.weight = weight;
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(avatar.transform.position+offset, avatar.transform.forward);
        Gizmos.DrawLine(avatar.transform.position+offset, cam.transform.position);
    }
}
[System.Serializable]
public class MultiAimConstraintGroup
{
    public List<MultiAimConstraint> MultiAimConstraints = new List<MultiAimConstraint>();
    public float minAngle = 45;
    public float maxAngle = 125;
    //public GameObject source;
}
