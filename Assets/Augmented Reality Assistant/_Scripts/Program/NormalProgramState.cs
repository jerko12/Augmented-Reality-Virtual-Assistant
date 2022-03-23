using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalProgramState : ProgramState
{
    public override void enter()
    {
        base.enter();
        //UIManager.Instance.showActionButton1(true);
        //UIManager.Instance.showActionButton2(true);
        Debug.Log("Normal State - enter");
    }

    public override void exit()
    {
        base.exit();
        Debug.Log("Normal State - exit");
    }

    public override void onTouchStarted(Vector2 _touchPos)
    {
        base.onTouchStarted(_touchPos);
        Debug.Log("Normal State - Touch started");
    }

    public override void onTouchEnded(Vector2 _touchPos)
    {
        base.onTouchStarted(_touchPos);
        Debug.Log("Normal State - Touch ended");
    }
}
