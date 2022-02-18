using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speech", menuName = "Avatar/Speech", order = 1)]
public class SpeechScriptableObject : ScriptableObject
{
    public List<Speech> speechSegments = new List<Speech>();
}

[System.Serializable]
public class Speech
{
    public string name = "";
    public AudioClip audio;

    Speech(string _name, AudioClip _audio)
    {
        name = _name;

        audio = _audio;
    }
}
