using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CreateAvatar : MonoBehaviour
{
    [SerializeField] string avatarName = "";
    [SerializeField] GameObject character;
    [SerializeField] DictionaryOfStringAndAudioClip speech;
    

    // Start is called before the first frame update
    async void Start()
    {
        AvatarManager.Instance.CreateAvatar(avatarName, character, speech);
        await Task.Delay(25);
        Avatar avatar = AvatarManager.Instance.currentAvatars[avatarName];
        await Task.Delay(1000);
        Debug.Log(avatar);
        avatar.Talk("Talk 1");

        //foreach(KeyValuePair<string,Avatar> currentAvatar in  AvatarManager.Instance.currentAvatars)
        //{
            //Debug.Log(currentAvatar.Key + " | " + currentAvatar.Value);
        //}
    }

    //public void Talk();
}
