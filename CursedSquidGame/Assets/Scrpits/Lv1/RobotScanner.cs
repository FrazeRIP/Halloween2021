using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScanner : MonoBehaviour
{
    SpriteRenderer SR;
    AudioSource AS;
    [SerializeField] AudioClip[] clips;
    [SerializeField] Sprite[] sprites;


    private static RobotScanner _instance;

    public static RobotScanner Instance { get { return _instance; } }


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
        AS = GetComponent<AudioSource>();
        SR = GetComponent<SpriteRenderer>();
        AS.Stop();
    }



    public void Do321()
    {
        SR.sprite = sprites[0];
        Movement.Instance.canMove = true;
        float progress = Movement.Instance.mainCamera.orthographicSize/Movement.Instance.InitialZoom;
        Debug.Log(progress);
        if  (progress>=.8)
        {
            PlayAndCountdown(Random.Range(0, 3));
            Debug.Log("Level 1 at progress " + progress);
        }
        else if (progress >= .6)
        {
            PlayAndCountdown(Random.Range(2, 5));
            Debug.Log("Level 2 at progress " + progress);
        }
        else
        {
            PlayAndCountdown(Random.Range(4, 7));
            Debug.Log("Level 3 at progress " + progress);
        }
    }


    void StartScan() {
        Movement.Instance.canMove = false;
        SR.sprite = sprites[1];
        Invoke("Do321", 3);

    }

    void DoMeme()
    {
        Debug.Log("Do meme");
    }

    void PlayAndCountdown(int index)
    {
        AS.clip = clips[index];
        Invoke("StartScan", AS.clip.length);
        AS.Play();
    }
}
