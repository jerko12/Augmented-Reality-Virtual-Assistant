using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : Singleton<PrefabManager>
{
    public Dictionary<string, GameObject> SceneGameObjects = new Dictionary<string, GameObject>();

    public void AddGameObject(string _name, GameObject _gameobject)
    {
        SceneGameObjects.Add(_name, _gameobject);
    }

    public GameObject GetGameObject(string _name)
    {
        if (!SceneGameObjects.ContainsKey(_name)) return null;
        return SceneGameObjects[_name];
    }
}
