using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogOnEvent : MonoBehaviour
{
    [SerializeField] string Text = "";

    public static void doDebug(string txt)
    {
        Debug.Log(txt);
    }

    public static void doDebug(Vector2 value)
    {
        Debug.Log("Vector2 value:" + value);
    }
}
