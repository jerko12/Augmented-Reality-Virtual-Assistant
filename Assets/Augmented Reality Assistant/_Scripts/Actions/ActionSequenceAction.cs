using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Action Sequence", menuName = "Action/Sequence", order = 1)]
public class ActionSequenceAction : ActionBase
{
    [SerializeField]private int index = 0;
    public List<ActionBase> Actions = new List<ActionBase>();

    public override void Finish()
    {
        index = 0;
        
        base.Finish();
    }

    public override void Perform()
    {
       
        Debug.Log("Sequence => Next in sequence");
        ActionBase action = Actions[index];
        action.OnFinished.AddListener(Perform);
        action.Perform();
        index++;
        if(index >= Actions.Count)
        {
            Finish();
        }

        base.Perform();
    }
}


