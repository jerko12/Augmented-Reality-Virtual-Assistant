using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Wolf3D.ReadyPlayerMe.AvatarSDK;

public class AvatarManager : Singleton<AvatarManager>
{
    public GameObject cam;
    public GameObject selectedAvatar;
    public GameObject avatarParent;
    public GameObject avatarTemplate;
    public Dictionary<string,Avatar> currentSpawnedAvatars = new Dictionary<string,Avatar>();

    private Queue<Avatar> avatarQueue = new Queue<Avatar>();
    #region avatar creation
    // Queue Avatar
    // Spawn Avatar
    // Place Avatar
    // Done


    private Avatar currentToPlaceAvatar;
    public Avatar CreateAvatar(string _name,GameObject _character)
    {

        Avatar spawnedAvatar = SpawnAvatar(_name, _character);
        currentSpawnedAvatars.Add(_name, spawnedAvatar);
        avatarQueue.Enqueue(spawnedAvatar);
        CheckQueue();
        return spawnedAvatar;
    }

    public void CheckQueue()
    {
        if (avatarQueue.Count <= 0) { ProgramManager.Instance.setNormal(); return; }
        if(currentToPlaceAvatar == null)
        {
            currentToPlaceAvatar = avatarQueue.Dequeue();
            ProgramManager.Instance.setAvatarPlaceState(currentToPlaceAvatar);
        }
    }

    public void NextQueue()
    {
        currentToPlaceAvatar = null;
        ProgramManager.Instance.SwitchState(ProgramManager.programState.startup);
        CheckQueue();
    }

    public void CreateAvatar(string _name,GameObject _character, DictionaryOfStringAndAudioClip _speech)
    {
        //Avatar spawnedAvatar = Instantiate(avatarTemplate,avatarParent.transform).GetComponent<Avatar>();
        //spawnedAvatar.gameObject.name = "Avatar " + _name;
        
        // Create the character of the avatar
        //GameObject character = Instantiate(_character,spawnedAvatar.transform);

        // Create the speech of the avatar
        //GameObject speechObject = new GameObject("Speech", typeof(AvatarSpeech));
        //AvatarSpeech speech = speechObject.GetComponent<AvatarSpeech>();
        //speech.speechCommands = _speech;
        //speechObject.transform.parent = spawnedAvatar.transform;

        //VoiceHandler voiceHandler = character.GetComponentInChildren<VoiceHandler>();
        //spawnedAvatar.Setup(speech,voiceHandler);

        //currentSpawnedAvatars.Add(_name, spawnedAvatar);
        
    }

    public Avatar SpawnAvatar(string _name, GameObject _character)
    {
        Avatar _spawnedAvatar = Instantiate(avatarTemplate, avatarParent.transform).GetComponent<Avatar>();
        _spawnedAvatar.gameObject.name = "Avatar " + _name;
        GameObject character = Instantiate(_character, _spawnedAvatar.transform);
        _spawnedAvatar.Setup();
        _spawnedAvatar.gameObject.SetActive(false);
        _spawnedAvatar.pause();
        return _spawnedAvatar;
    }
    #endregion

    public Avatar GetAvatar(string _name)
    {
        if (!currentSpawnedAvatars.ContainsKey(_name)) return null;
        return currentSpawnedAvatars[_name];
    }

    public void SetAvatarDestination(Vector3 destination)
    {
        if (selectedAvatar == null) return;
        selectedAvatar.GetComponent<AvatarWalkTowards>().SetDestination(destination);
    }

    public void InteractWithAvatar()
    {
        Vector3 lookAtLocation = cam.transform.position.Flat() + Vector3.up * selectedAvatar.transform.position.y;
        selectedAvatar.transform.LookAt(lookAtLocation);
        selectedAvatar.GetComponent<AvatarAnimator>().Interact();
    }

    public void TeleportAvatar(Vector3 destination)
    {
        if (selectedAvatar == null) return;
        selectedAvatar.transform.position = destination;
        selectedAvatar.GetComponent<AvatarWalkTowards>().SetDestination(destination);
    }
}
