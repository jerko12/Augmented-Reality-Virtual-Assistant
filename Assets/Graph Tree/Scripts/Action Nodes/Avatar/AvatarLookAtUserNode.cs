using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarLookAtUserNode : ActionNode
{
    public string avatarName = "";
    public string lookAtAvatarName = "";
    public Vector3 offset;


    Avatar avatar;
    Avatar avatarTarget;
    private bool IKSet = false;

    protected override void OnStart()
    {
        IKSet = false;
        AvatarManager.Instance.currentSpawnedAvatars.TryGetValue(avatarName, out avatar);
        AvatarManager.Instance.currentSpawnedAvatars.TryGetValue(lookAtAvatarName, out avatarTarget);
        if (avatar && avatarTarget)
        {
            avatar.LookAtGameobject(avatarTarget.transform,offset);
        }
        IKSet = true;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if (!IKSet)
        {
            return State.Running;
        }

        if(avatar && avatarTarget)
        {
            return State.Success;
        }

        return State.Failure;
    }
}
