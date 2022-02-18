using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechHandler : MonoBehaviour
{
    [SerializeField]SpeechScriptableObject currentSpeech;
    int currentIndex;

    public void reset()
    {
        currentIndex = 0;
        ProgramManager.Instance.normal.onTouchEnter.AddListener(start);
    }

    public void speechSegmentCompleted(Avatar avatar)
    {
        Debug.Log("Speech => Segment Completed");
        avatar.onTalkCompleted.RemoveListener(speechSegmentCompleted);
        next();
    }

    public void next()
    {
        
        if (currentIndex >= currentSpeech.speechSegments.Count) return;
        
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
    }

    public void start(Vector2 touchLocation)
    {
        ProgramManager.Instance.normal.onTouchEnter.RemoveListener(start);


        next();
    }

    private void Start()
    {
        reset();
    }

}
