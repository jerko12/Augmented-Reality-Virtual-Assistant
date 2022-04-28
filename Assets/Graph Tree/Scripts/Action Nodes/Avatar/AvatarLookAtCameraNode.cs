using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarLookAtCameraNode : ActionNode
{
    public string avatarName = "";
    public Vector3 offset;
    Avatar avatar;
    protected override void OnStart()
    {
        AvatarManager.Instance.currentSpawnedAvatars.TryGetValue(avatarName, out avatar);
        if (avatar)
        {
            avatar.LookAtGameobject(Camera.main.transform, offset);
        }
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if (avatar)
        {
            return State.Success;
        }

        return State.Failure;
    }
}
