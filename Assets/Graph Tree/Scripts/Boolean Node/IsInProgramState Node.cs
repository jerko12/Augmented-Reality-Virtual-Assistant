using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInProgramStateNode : BooleanNode
{
    public ProgramManager.programState programState = ProgramManager.programState.normal;
    protected override void OnStart()
    {
        boolean = ProgramManager.Instance.currentState == programState;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        var child = boolean ? childPositive : childNegative;
        switch (child.Update())
        {
            case State.Running:
                return State.Running;
            case State.Failure:
                return State.Failure;
            case State.Success:
                break;
        }

        return child.state == State.Success ? State.Success : State.Running;
    }
}
