using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wolf3D.ReadyPlayerMe.AvatarSDK;

public class Avatar : MonoBehaviour
{
    [SerializeField] AvatarSpeech speech;
    [SerializeField] VoiceHandler voiceHandler;

    public void Setup(AvatarSpeech _speech, VoiceHandler _voiceHandler)
    {
        speech = _speech;
        voiceHandler = _voiceHandler;
    }

    public void Talk(string command)
    {
        AudioClip voice = speech.speechCommands[command];
        if (voice != null)
        {
            voiceHandler.AudioClip = voice;
            voiceHandler.PlayAudioClip(voice);
            Debug.Log("Talk: " + voiceHandler.AudioClip.name);
            //voiceHandler.PlayCurrentAudioClip();
        }


    }

    public void Talk(AudioClip audioClip)
    {

        Debug.Log("Talk: " + audioClip.name);
        voiceHandler.PlayCurrentAudioClip();
    }
}
