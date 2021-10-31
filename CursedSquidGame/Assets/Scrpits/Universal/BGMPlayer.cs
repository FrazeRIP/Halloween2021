using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGMPlayer : MonoBehaviour
{
    public AudioSource AS;
    #region Singleton
    private static BGMPlayer _instance;
    public static BGMPlayer Instance { get { return _instance; } }
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


    void Start()
    {
        AS = GetComponent<AudioSource>();
        AS.clip = AudioManager.Instance.BGMClip;
        AS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
