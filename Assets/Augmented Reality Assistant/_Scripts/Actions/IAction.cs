using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IAction 
{
    public UnityEvent OnFinished { get; }
    public void Perform();

    public void Finish();
    
}
