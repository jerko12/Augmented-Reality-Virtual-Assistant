using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AvatarActions : MonoBehaviour
{
    public void SpawnAvatar()
    {

    }

    public void MoveAvatar(Vector3 worldPosition)
    {
        if (AvatarManager.Instance == null) return;

        AvatarManager.Instance.SetAvatarDestination(worldPosition);
    }

    public void TeleportAvatar(Vector3 worldPosition)
    {
        if (AvatarManager.Instance == null) return;

        AvatarManager.Instance.TeleportAvatar(worldPosition);
    }
}
