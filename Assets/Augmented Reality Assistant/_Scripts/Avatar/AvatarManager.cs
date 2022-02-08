using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Wolf3D.ReadyPlayerMe.AvatarSDK;

public class AvatarManager : Singleton<AvatarManager>
{
    public GameObject cam;
    public GameObject currentAvatar;
    public GameObject avatarParent;
    public GameObject avatarTemplate;
    public Dictionary<string,Avatar> currentAvatars = new Dictionary<string,Avatar>();

    #region avatar creation
    public void CreateAvatar(string _name,GameObject _character, DictionaryOfStringAndAudioClip _speech)
    {
        Avatar spawnedAvatar = Instantiate(avatarTemplate,avatarParent.transform).GetComponent<Avatar>();
        spawnedAvatar.gameObject.name = "Avatar " + _name;
        
        // Create the character of the avatar
        GameObject character = Instantiate(_character,spawnedAvatar.transform);

        // Create the speech of the avatar
        GameObject speechObject = new GameObject("Speech", typeof(AvatarSpeech));
        AvatarSpeech speech = speechObject.GetComponent<AvatarSpeech>();
        speech.speechCommands = _speech;
        speechObject.transform.parent = spawnedAvatar.transform;

        VoiceHandler voiceHandler = character.GetComponentInChildren<VoiceHandler>();
        spawnedAvatar.Setup(speech,voiceHandler);

        currentAvatars.Add(_name, spawnedAvatar);
        
    }
    #endregion


    public void SetAvatarDestination(Vector3 destination)
    {
        if (currentAvatar == null) return;
        currentAvatar.GetComponent<AvatarWalkTowards>().SetDestination(destination);
    }

    public void InteractWithAvatar()
    {
        Vector3 lookAtLocation = cam.transform.position.Flat() + Vector3.up * currentAvatar.transform.position.y;
        currentAvatar.transform.LookAt(lookAtLocation);
        currentAvatar.GetComponent<AvatarAnimator>().Interact();
    }

    public void TeleportAvatar(Vector3 destination)
    {
        if (currentAvatar == null) return;
        currentAvatar.transform.position = destination;
        currentAvatar.GetComponent<AvatarWalkTowards>().SetDestination(destination);
    }
}
