using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    [SerializeField] AudioClip footstepSound;


    AudioSource AS;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
        AS.clip = footstepSound;
    }

    public void PlayFootstep()
    {
        AS.Play();
    }
}
