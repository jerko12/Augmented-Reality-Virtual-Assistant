using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesSystem : PersistentSingleton<ScenesSystem>
{

    private async void Start()
    {
        loadSceneByName("AR Assistant Scene",LoadSceneMode.Additive);
        await Task.Delay(25);
        loadSceneByName("User Interface", LoadSceneMode.Additive);
    }

    /// <summary>
    /// Load a scene by name if it is not already loaded. 
    /// </summary>
    /// <param name="SceneName"></param>
    /// <param name="loadSceneMode"></param>
    public void loadSceneByName(string SceneName,LoadSceneMode loadSceneMode)
    {
        if (SceneManager.GetSceneByName(SceneName).isLoaded == false) SceneManager.LoadScene(SceneName, loadSceneMode);
    }

    public void loadARScenes()
    {

    }
}
