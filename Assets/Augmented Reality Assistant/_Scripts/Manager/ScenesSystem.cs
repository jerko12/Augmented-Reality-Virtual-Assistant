using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesSystem : PersistentSingleton<ScenesSystem>
{

    private void Start()
    {
        if(SceneManager.GetSceneByName("User Interface").isLoaded == false) SceneManager.LoadScene("User Interface", LoadSceneMode.Additive);
    }


    public void loadARScenes()
    {

    }
}
