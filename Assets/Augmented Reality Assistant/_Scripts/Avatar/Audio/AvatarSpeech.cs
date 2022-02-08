using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AvatarSpeech : MonoBehaviour
{
    public DictionaryOfStringAndAudioClip speechCommands;
}

public class Speech
{
    string name = "";
    AudioClip audio;

    Speech(string _name, AudioClip _audio)
    {
        name = _name;
        
        audio = _audio;
    }
}
