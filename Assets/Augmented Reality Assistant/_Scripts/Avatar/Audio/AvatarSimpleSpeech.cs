using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AvatarSimpleSpeech : MonoBehaviour
{
    public DictionaryOfStringAndAudioClip speechCommands;

    public async Task playSpeechCommand(KeyValueClass<string,AudioClip> currentSpeechCommand)
    {
        Avatar currentAvatar;
        if(AvatarManager.Instance.currentSpawnedAvatars.TryGetValue(currentSpeechCommand.key,out currentAvatar))
        {
            //Task currentTask = currentAvatar.Talk(currentSpeechCommand.value);
            //await currentAvatar.Talk();

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
