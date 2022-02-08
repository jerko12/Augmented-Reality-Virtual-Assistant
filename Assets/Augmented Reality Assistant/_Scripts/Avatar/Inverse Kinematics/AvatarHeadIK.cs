using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AvatarHeadIK : MonoBehaviour
{
    [SerializeField] RigBuilder rigBuilder;
    [SerializeField]MultiAimConstraint headIK;
    [SerializeField]MultiAimConstraint neckIK;
    [SerializeField]MultiAimConstraint shoulderIK;
    [SerializeField]MultiAimConstraint spineIK;

    // Start is called before the first frame update
    void Start()
    {
        var headData = headIK.data.sourceObjects;
        headData.SetTransform(0, AvatarManager.Instance.cam.transform);
        headIK.data.sourceObjects = headData;
        //headIK.data.sourceObjects.SetWeight(0,.6f);
        //headIK.data.sourceObjects.SetTransform(1, );

        var neckData = neckIK.data.sourceObjects;
        neckData.SetTransform(0, AvatarManager.Instance.cam.transform);
        neckIK.data.sourceObjects = neckData; 

        var shoulderData = shoulderIK.data.sourceObjects;
        shoulderData.SetTransform(0, AvatarManager.Instance.cam.transform);
        shoulderIK.data.sourceObjects = shoulderData;
        
        var spineData = spineIK.data.sourceObjects;
        spineData.SetTransform(0, AvatarManager.Instance.cam.transform);
        spineIK.data.sourceObjects = spineData;

        //headIK.data.sourceObjects.Add(new WeightedTransform(AvatarManager.Instance.cam.transform, .5f));

        //shoulderIK.data.sourceObjects.SetWeight(1,.45f);
        //shoulderIK.data.sourceObjects.SetTransform(1, AvatarManager.Instance.cam.transform);
        
        //spineIK.data.sourceObjects.SetWeight(0,.40f);
        //spineIK.data.sourceObjects.SetTransform(0, AvatarManager.Instance.cam.transform);

        rigBuilder.Build();
    }
}
