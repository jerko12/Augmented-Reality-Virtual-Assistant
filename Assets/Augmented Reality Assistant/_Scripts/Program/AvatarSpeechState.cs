using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSpeechState : ProgramState
{
    public override void enter()
    {
        base.enter();
        UIManager.Instance.showActionButton1(false);
        UIManager.Instance.showActionButton2(false);
    }

    public override void exit()
    {
        base.exit();
    }
}
