using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Prefab Action", menuName = "Action/Prefab Action", order = 1)]
public class ShowHidePrefabAction : ActionBase
{
    public string prefabName = "";
    public string avatarName = "";

    public Vector3 position;
    public Vector3 rotation;

    public bool showObject = true;

    public override void Finish()
    {
        Debug.Log("Action => show Prefab " + prefabName + " Finished");
        base.Finish();
    }

    public override void Perform()
    {
        
        base.Perform();
        if (showObject)
        {
            Debug.Log("Action => Show Prefab " + prefabName);
            ShowPrefab();
        }
        else
        {
            Debug.Log("Action => Hide Prefab " + prefabName);
            HidePrefab();
        }

        waitForFinish();
    }

    public async void waitForFinish()
    {
        await Task.Delay(250);
        Finish();
    }

    public void ShowPrefab()
    {
        GameObject _prefab = PrefabManager.Instance.GetGameObject(prefabName);
        Avatar _avatar = AvatarManager.Instance.GetAvatar(avatarName);

        if (_prefab == null) return;
        _prefab.SetActive(true);

        if (_avatar == null) return;
        _prefab.transform.position = _avatar.transform.position + position.RelativeVector(_avatar.transform);
        _prefab.transform.rotation = _avatar.transform.rotation * Quaternion.Euler(rotation);

    }

    public void HidePrefab()
    {
        GameObject _prefab = PrefabManager.Instance.GetGameObject(prefabName);
        if (_prefab == null) return;
        _prefab.transform.position = Vector3.zero;
        _prefab.transform.rotation = Quaternion.identity;
        _prefab.SetActive(false);
    }
}
