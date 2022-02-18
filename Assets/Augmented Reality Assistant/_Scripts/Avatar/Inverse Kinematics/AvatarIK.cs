using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AvatarIK : MonoBehaviour
{
    [SerializeField] RigBuilder rigBuilder;
    [SerializeField] private MultiAimConstraintGroup headIK = new MultiAimConstraintGroup();
    [SerializeField] private MultiAimConstraintGroup eyeIK = new MultiAimConstraintGroup();
    [SerializeField] private GameObject avatar;
    [SerializeField] private Vector3 offset;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        headIK.SetMultiAimTarget(cam.gameObject);
        eyeIK.SetMultiAimTarget(cam.gameObject);

        rigBuilder.Build();
    }



    // Update is called once per frame
    void Update()
    {
        //WeightedTransformArray currentSources = headIK.MultiAimConstraints[0].data.sourceObjects;
        Vector3 direction = ( cam.transform.position - (avatar.transform.position + offset)).normalized;
        float currentHeadAngle = Vector3.Angle(avatar.transform.forward, direction);
        
        if(currentHeadAngle < headIK.minAngle)
        {
            headIK.SetMultiAimWeights(1);
            //SetMultiAimGroupWeight(headIK,1);
        }
        else
        {
            //Debug.Log("Angle: " + (currentHeadAngle - headIK.maxAngle));
            headIK.SetMultiAimWeights(headIK.GetSmoothWeight(currentHeadAngle));
            //SetMultiAimGroupWeight(headIK,getSmoothWeight(angle,headIK.minAngle,headIK.maxAngle));
        }
    }

    /*

    public float getSmoothWeight(float currentAngle,float minAngle,float maxAngle)
    {
        return Mathf.Clamp(1 -(currentAngle- minAngle)/(maxAngle-minAngle),0,1);
    }

    public void SetMultiAimGroupWeight(MultiAimConstraintGroup aimContrainGroup,float weight)
    {
        foreach(MultiAimConstraint aimConstrain in aimContrainGroup.MultiAimConstraints)
        {
            aimConstrain.weight = weight;
            
        }
    }
    */

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(avatar.transform.position+offset, avatar.transform.forward);
        if (cam == null) return;
        Gizmos.DrawLine(avatar.transform.position+offset, cam.transform.position);
    }
}
[System.Serializable]
public class MultiAimConstraintGroup
{
    public List<MultiAimConstraint> MultiAimConstraints = new List<MultiAimConstraint>();
    public float minAngle = 45;
    public float maxAngle = 125;
    public GameObject target;

    public void SetMultiAimTarget(GameObject target)
    {
        foreach (MultiAimConstraint constraint in MultiAimConstraints)
        {
            SetMultiAimSources(constraint, target);
        }
    }

    private void SetMultiAimSources(MultiAimConstraint constraint,GameObject target)
    {
        var constraintData = constraint.data.sourceObjects;
        constraintData.SetTransform(0, target.transform);
        constraint.data.sourceObjects = constraintData;
    }

    public void SetMultiAimWeights(float weight)
    {
        foreach (MultiAimConstraint aimConstrain in MultiAimConstraints)
        {
            aimConstrain.weight = weight;
        }
    }

    public float GetSmoothWeight(float currentAngle)
    {
        return Mathf.Clamp(1 - (currentAngle - minAngle) / (maxAngle - minAngle), 0, 1);
    }
}
