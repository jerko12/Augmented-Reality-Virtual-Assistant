using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Wolf3D.ReadyPlayerMe.AvatarSDK;

public class Avatar : MonoBehaviour
{
    [SerializeField] AvatarSpeech speech;
    [SerializeField] VoiceHandler voiceHandler;
    [SerializeField] AvatarAnimator animator;
    [SerializeField] NavMeshAgent agent;

    public UnityEvent<Avatar> onTalkCompleted;

    public void Setup()
    {
        //speech = _speech;
        voiceHandler = GetComponentInChildren<VoiceHandler>();
    }

    public void start()
    {
        agent.enabled = true;
    }

    public void pause()
    {
        agent.enabled = false;
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
            StartCoroutine(waitForTalkCompleted());
        }
        
        //return;
    }

    public void Talk(AudioClip audioClip)
    {

        Debug.Log("Talk: " + audioClip.name);
        voiceHandler.PlayAudioClip(audioClip);
        StartCoroutine(waitForTalkCompleted());
    }

    IEnumerator waitForTalkCompleted()
    {
        yield return new WaitWhile(() => voiceHandler.AudioSource.isPlaying);
        Debug.Log("Talk Completed");
        onTalkCompleted?.Invoke(this);
    }

    private void Start()
    {
        animator = GetComponentInChildren<AvatarAnimator>();
        agent = GetComponent<NavMeshAgent>();
    }

    Vector3 previousLocation = Vector3.zero;
    private void Update()
    {

        //Not good code. CHANGE LATER
        if(animator == null) { animator = GetComponentInChildren<AvatarAnimator>(); } else
        {
            animator.UpdateMovementDirection(previousLocation - transform.position);
            previousLocation = transform.position;
        }
        
    }
}
