using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogOnEvent : MonoBehaviour
{
    [SerializeField] string Text = "";

    public void doDebug()
    {
        Debug.Log(Text);
    }

    public void doDebug(Vector2 value)
    {
        Debug.Log(Text + " - " + value);
    }
}
