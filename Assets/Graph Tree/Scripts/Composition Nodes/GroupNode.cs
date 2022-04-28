using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupNode : CompositeNode
{
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        bool completed = true;
        children.ForEach(child => { 
            if(child.Update() == State.Running)
            {
                completed = false;
            }
        });

        if (completed)
        {
            return State.Success;
        }

        return State.Running;
    }
}
