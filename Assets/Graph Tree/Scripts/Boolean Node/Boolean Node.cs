using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BooleanNode : Node
{
    [HideInInspector] public Node childPositive;
    [HideInInspector] public Node childNegative;

    public bool boolean;

    public override Node Clone()
    {
        BooleanNode node = Instantiate(this);
        node.childPositive = childPositive.Clone();
        node.childNegative = childNegative.Clone();
        return node;
    }

}
