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
    [SerializeField] AvatarIK IK;
    [SerializeField] NavMeshAgent agent;

    public UnityEvent<Avatar> onTalkCompleted;
    public UnityEvent onTalkComplete;

    public UnityEvent onAvatarPlaced;

    public void Setup()
    {
        //speech = _speech;
        voiceHandler = GetComponentInChildren<VoiceHandler>();
    }

    public void start()
    {
        //agent.enabled = true;
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
            animator.StartTalking();
            //voiceHandler.PlayCurrentAudioClip();
            StartCoroutine(waitForTalkCompleted());
        }
        
        //return;
    }

    public void Talk(AudioClip audioClip)
    {

        Debug.Log("Talk: " + audioClip.name);
        voiceHandler.PlayAudioClip(audioClip);
        animator.StartTalking();
        StartCoroutine(waitForTalkCompleted());
    }

    IEnumerator waitForTalkCompleted()
    {
        yield return new WaitWhile(() => voiceHandler.AudioSource.isPlaying);
        Debug.Log("Talk Completed");
        animator.StopTalking();
        onTalkCompleted?.Invoke(this);
        onTalkComplete?.Invoke();
    }

    public void LookAtGameobject(Transform target,Vector3 offset)
    {
        IK.SetHeadTarget(target,offset);
    }

    private void Start()
    {
        animator = GetComponentInChildren<AvatarAnimator>();
        IK = GetComponentInChildren<AvatarIK>();
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
