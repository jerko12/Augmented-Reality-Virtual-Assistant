using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionHandler : MonoBehaviour
{
    [SerializeField]ActionSequenceAction currentActionSequence;
    [SerializeField] int currentIndex;

    public UnityEvent onStart;
    public UnityEvent onNext;

    public void reset()
    {
        currentIndex = 0;
        
    }

    //public void speechSegmentCompleted(Avatar avatar)
    //{
        //Debug.Log("Speech => Segment Completed");
        //avatar.onTalkCompleted.RemoveListener(speechSegmentCompleted);
        //next();
    //}

    public void next()
    {
        /*
        if (currentIndex >= currentSpeech.speechSegments.Count)
        {
            ProgramManager.Instance.setNormal();
            return;
        }
        Avatar avatar;
        if(AvatarManager.Instance.currentSpawnedAvatars.TryGetValue(currentSpeech.speechSegments[currentIndex].name,out avatar))
        {
            Debug.Log("Speech => Next");
            avatar.onTalkCompleted.AddListener(speechSegmentCompleted);
            avatar.Talk(currentSpeech.speechSegments[currentIndex].audio);
            
        }
        else
        {
            Debug.LogWarning("Avatar with name " + currentSpeech.speechSegments[currentIndex].name +  " not found!" );
        }
        currentIndex++;
        */
        Debug.Log("Action Handler = > Next");
        if (currentIndex >= currentActionSequence.Actions.Count)
        {
            ProgramManager.Instance.setNormal();
            return;
        }
        //currentActionSequence.OnFinished += 
        currentActionSequence.Perform();

        //currentActionSequence.Actions[currentIndex].OnFinished.AddListener(next);
        //currentActionSequence.Actions[currentIndex].Perform();
        currentIndex++;
    }

    public void onTouch(Vector2 touchLocation)
    {
        ProgramManager.Instance.normal.onTouchEnter.RemoveListener(onTouch);
        start();
    }

    public void start()
    {
        reset();
        Debug.Log("Action Handler = > Start");
        ProgramManager.Instance.normal.onStateEnter.RemoveListener(start);
        onStart?.Invoke();
        next();
    }

    private void Start()
    {
        reset(); ProgramManager.Instance.normal.onStateEnter.AddListener(start);
    }

}
