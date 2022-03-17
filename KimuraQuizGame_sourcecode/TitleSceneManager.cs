using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    public void LoadTo(string sceneName)
    {
        FadeIOManager.instance.FadeOutToIn( () => Load(sceneName));
    }

    void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
