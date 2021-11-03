using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class JumpScare : MonoBehaviour
{

    public static int totalJumpScareOnScreen;

    public void OnEnable()
    {
        totalJumpScareOnScreen++;
    }

    public void SelfDestoryCountdown(float t)
    {
        Invoke("DestroySelf", t);
    }
    public void SelfDestoryCountdown()
    {
        Invoke("DestroySelf", (float)GetComponent<VideoPlayer>().clip.length);
    }


    void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        totalJumpScareOnScreen--;
    }
}
