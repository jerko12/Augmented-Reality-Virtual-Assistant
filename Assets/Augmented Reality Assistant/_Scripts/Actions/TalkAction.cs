using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Talk Action", menuName = "Action/Talk Action", order = 1)]
public class TalkAction : ActionBase
{
    public string avatarName = "";
    public AudioClip audioClip;
    Avatar avatar;
    public override void Finish()
    {
        Debug.Log("Action => Finish Talk Action");
        base.Finish();
        avatar.onTalkComplete.RemoveListener(Finish);
        
    }

    public void debug()
    {
        Debug.Log("Yeah this works");
    }

    public override void Perform()
    {
        base.Perform();
        Debug.Log("Action => Start Talk Action");
        //Avatar avatar;
        if (AvatarManager.Instance.currentSpawnedAvatars.TryGetValue(avatarName, out avatar))
        {
            avatar.onTalkComplete.AddListener(Finish);
            OnFinished.AddListener(debug);
            avatar.Talk(audioClip);
        }
        else
        {
            Debug.LogWarning("Avatar with name " + avatarName + " not found!");
        }
    }
}
