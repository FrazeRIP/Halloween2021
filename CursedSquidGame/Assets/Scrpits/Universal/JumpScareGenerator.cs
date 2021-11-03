using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

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


    GameObject canvas;

    private void Start()
    {
        canvas = GameObject.FindWithTag("Canvas");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            GenerateJumpScare();
        }
    }

    public void GenerateJumpScare()
    {
        float xPos = Random.Range(0, Screen.width);
        float yPos = Random.Range(0, Screen.height);
        Vector3 spawnPosition = new Vector3(xPos, yPos, 0f);
        GameObject spwanObj = Instantiate(jumpScarePrefeb, spawnPosition, Quaternion.identity) as GameObject;
        RenderTexture rt = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
        rt.Create();
        spwanObj.GetComponent<RawImage>().texture = rt;
        spwanObj.GetComponent<VideoPlayer>().targetTexture = rt;
        spwanObj.GetComponent<VideoPlayer>().clip = Clip;
        spwanObj.GetComponent<VideoPlayer>().clip = Clip;
        spwanObj.transform.parent = canvas.transform;
        spwanObj.transform.position = spawnPosition;
        spwanObj.GetComponent<VideoPlayer>().Play();
        spwanObj.GetComponent<JumpScare>().SelfDestoryCountdown();
    }



}
