using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneSwitch : MonoBehaviour
{
    public string sceneName;

    #region Singleton
    private static SimpleSceneSwitch _instance;
    public static SimpleSceneSwitch Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        //DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
