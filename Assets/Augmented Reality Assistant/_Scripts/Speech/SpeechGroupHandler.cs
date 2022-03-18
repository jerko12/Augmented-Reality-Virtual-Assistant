using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechGroupHandler : MonoBehaviour
{
    public SpeechHandler speech1;
    public SpeechHandler speech2;


    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.action1Button.onClick.AddListener(startSpeech1);
        UIManager.Instance.action2Button.onClick.AddListener(startSpeech2);
    }

    public void startSpeech1()
    {
        ProgramManager.Instance.setAvatarSpeechState();
        speech1.start();
    }

    public void startSpeech2()
    {
        ProgramManager.Instance.setAvatarSpeechState();
        speech2.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class SpeechGroup
{

}