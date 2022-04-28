using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySequenceTree : ActionNode
{
    public SequenceTree treeToPlay;

    protected override void OnStart()
    {
        treeToPlay = treeToPlay.Clone();
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if (treeToPlay)
        {
            State state = treeToPlay.rootNode.Update();
            return state;
        }
        else
        {
            return State.Failure;
        }
    }
}
