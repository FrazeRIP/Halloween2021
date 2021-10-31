using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetryMenu : MonoBehaviour
{
    [System.Serializable]
    public class MemePair
    {
        public Sprite memeImage;
        public AudioClip memeClip;
    }

    [SerializeField] MemePair[] memes;

    AudioSource m_AudioSource;
    Image m_RawImage;

    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        //Fetch the RawImage component from the GameObject
        m_RawImage = GetComponent<Image>();

        DoUI(memes[Random.Range(0, memes.Length)]);

    }

    public void DoUI(MemePair pair)
    {
        m_AudioSource.clip = pair.memeClip;
        m_AudioSource.Play();
        m_RawImage.sprite = pair.memeImage;
    }
}
