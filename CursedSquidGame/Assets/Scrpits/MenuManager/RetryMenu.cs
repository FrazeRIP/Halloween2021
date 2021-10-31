using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetryMenu : MonoBehaviour
{
    AudioSource m_AudioSource;
    public AudioClip[] audioClips;

    RawImage m_RawImage;
    public Texture[] images;

    int range;
    int randomNum;

    void Start()
    {
        if (audioClips.Length != images.Length)
        {
            if (audioClips.Length > images.Length) 
            {
                range = images.Length;
            }
            else
            {
                range = audioClips.Length;
            }
        }

        randomNum = Random.Range(0, range);
        
        CallAudio(randomNum);
        InvokeImage(randomNum);

    }

    public void CallAudio(int num)
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.clip = audioClips[num];
    }

    public void InvokeImage(int num)
    {

        //Fetch the RawImage component from the GameObject
        m_RawImage = GetComponent<RawImage>();
        //Change the Texture to be the one define in the Inspector
        m_RawImage.texture = images[num];

    }
}
