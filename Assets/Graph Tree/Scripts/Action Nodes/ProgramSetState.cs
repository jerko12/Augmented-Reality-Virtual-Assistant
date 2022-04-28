using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramSetState : ActionNode
{
    ProgramManager.programState state = ProgramManager.programState.normal;
    protected override void OnStart()
    {
        ProgramManager.Instance.currentState = state;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        return State.Success;
    }
}
