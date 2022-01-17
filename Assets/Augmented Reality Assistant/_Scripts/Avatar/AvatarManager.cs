using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AvatarManager : Singleton<AvatarManager>
{
    public GameObject cam;
    public GameObject currentAvatar;

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
