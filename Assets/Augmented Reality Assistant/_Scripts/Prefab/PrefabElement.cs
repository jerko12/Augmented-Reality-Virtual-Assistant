using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabElement : MonoBehaviour
{
    public string prefabName;

    public string avatarName;

    public void Show()
    {
        Avatar avatar = AvatarManager.Instance.GetAvatar("Marcel");
        transform.position = avatar.transform.position;
        transform.rotation = avatar.transform.rotation;

        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        PrefabManager.Instance.AddGameObject(name, gameObject);

        

        gameObject.SetActive(false);
    }
}
