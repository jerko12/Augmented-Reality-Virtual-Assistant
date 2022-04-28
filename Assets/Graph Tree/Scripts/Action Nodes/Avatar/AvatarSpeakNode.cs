using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSpeakNode : ActionNode
{
    public string avatarName = "";
    public AudioClip audioClip;
    public bool waitToFinish = true;

    Avatar avatar;
    private bool isTalking = true;

    protected override void OnStart()
    {
        AvatarManager.Instance.currentSpawnedAvatars.TryGetValue(avatarName, out avatar);
        isTalking = true;
        if (avatar)
        {
            avatar.onTalkComplete.RemoveListener(FinishedTalking);
            avatar.onTalkComplete.AddListener(FinishedTalking);
            avatar.Talk(audioClip);
        }
    }

    protected override void OnStop()
    {
        avatar.onTalkComplete.RemoveListener(FinishedTalking);
    }

    public void FinishedTalking()
    {
        isTalking = false;
    }

    protected override State OnUpdate()
    {
        if (avatar)
        {
            
            if (isTalking)
            {
                return State.Running;
            }
            else
            {
                return State.Success;
            }  
        }
        else{
            return State.Failure;
        }
    }
}
