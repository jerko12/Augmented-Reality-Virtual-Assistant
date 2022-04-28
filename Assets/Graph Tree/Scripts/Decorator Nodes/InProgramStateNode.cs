using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InProgramStateNode : DecoratorNode
{
    public ProgramManager.programState stateToCheck;
    public bool boolean;
    public bool positive;
    //public string description = "use a boolean to decide to run child";
    
    protected override void OnStart()
    {
        boolean = (stateToCheck == ProgramManager.Instance.currentState);
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        boolean = (stateToCheck == ProgramManager.Instance.currentState);
        if (boolean)
        {
            State childState = child.Update();
            return childState;
        }
        
        return State.Success;
    }
}
