using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarCreateNode : ActionNode
{
    [SerializeField] AvatarSettings avatarSettings;
    Avatar avatar;
    bool avatarPlaced = false;
    

    protected override void OnStart()
    {
        if (avatar == null)
        {
            avatar = AvatarManager.Instance.CreateAvatar(avatarSettings.avatarName, avatarSettings.characterPrefab);
            avatar.onAvatarPlaced.AddListener(AvatarPlaced);
        }
    }
    public void AvatarPlaced()
    {
        avatarPlaced = true;
        avatar.onAvatarPlaced.RemoveListener(AvatarPlaced);
    }


    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if (avatarPlaced) return State.Success;

        return State.Running;
    }
}
