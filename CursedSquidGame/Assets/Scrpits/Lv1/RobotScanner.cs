using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class RobotScanner : MonoBehaviour
{
    SpriteRenderer SR;
    AudioSource AS;
    [SerializeField] VideoPlayer VP;

    [SerializeField] AudioClip[] clips;
    [SerializeField] VideoClip[] videos;
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject[] guns;
    [SerializeField] GameObject blood;
    [SerializeField] AudioClip gunClip;

    private static RobotScanner _instance;

    public static RobotScanner Instance { get { return _instance; } }


    bool isScanning = false;

    [SerializeField] float cd1 = 0;
    [SerializeField] float cd2 = 0;

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
        VP.Stop();
        VP.gameObject.SetActive(false);
    }


    private void Update()
    {
        cd1 -= Time.deltaTime;
        cd2 -= Time.deltaTime;
        if (!Movement.Instance.canMove)
        {
            GunDetect(guns[0], ref cd1);
            GunDetect(guns[1], ref cd2);
        }
    }


    public void Do321()
    {
        VP.Stop();
        VP.gameObject.SetActive(false);
        SR.sprite = sprites[0];
        Movement.Instance.canMove = true;
        float progress = Movement.Instance.mainCamera.orthographicSize / Movement.Instance.InitialZoom;
        if (progress >= .8)
        {
            PlayAndCountdown(Random.Range(0, 3));
        }
        else if (progress >= .6)
        {
            PlayAndCountdown(Random.Range(2, 5));
        }
        else
        {
            PlayAndCountdown(Random.Range(4, 7));
        }
    }


    void StartScan()
    {
        Movement.Instance.canMove = false;
        SR.sprite = sprites[1];
        VP.clip = videos[Random.Range(0, videos.Length)];
        VP.gameObject.SetActive(true);
        VP.Play();
        Invoke("Do321", (float)VP.clip.length);
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



    void GunDetect(GameObject gun, ref float cd)
    {
        if (cd<0 && Random.Range(0, 1.0f) < 0.0025f)
        {
            gun.GetComponent<Image>().color = Color.white;
            gun.GetComponent<AudioSource>().PlayOneShot(gunClip);
            gun.GetComponent<AudioSource>().PlayOneShot(AudioManager.Instance.HurtClip);
            cd = Random.Range(1f, 3f);
        }

    }

    public void Dead()
    {
        //blood.GetComponent<Image>().color = new Color(Color.red.r, Color.red.g, Color.red.b, 0);
        blood.GetComponent<SimpleFadeOut>().enabled = true;
        blood.GetComponent<AudioSource>().PlayOneShot(gunClip);
        blood.GetComponent<AudioSource>().PlayOneShot(AudioManager.Instance.HurtClip);
    }
}
