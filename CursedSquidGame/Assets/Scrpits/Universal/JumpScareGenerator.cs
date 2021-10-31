using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class JumpScareGenerator : MonoBehaviour
{
    #region Singleton
    private static JumpScareGenerator _instance;
    public static JumpScareGenerator Instance { get { return _instance; } }
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

    [SerializeField] VideoClip[] _clips;
    public VideoClip Clip { get { return _clips[Random.Range(0, _clips.Length)]; } }

    [SerializeField] GameObject jumpScarePrefeb;



}
