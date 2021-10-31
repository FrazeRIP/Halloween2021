using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleFadeOut : MonoBehaviour
{
    [SerializeField] bool fadingOut = true;

    Image img;
    [SerializeField] float fadeSpeed;
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingOut)
        {
            if (img.color.a > 0)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a - Time.deltaTime * fadeSpeed);
            }
        }
        else
        {
                img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a + Time.deltaTime * fadeSpeed);
        }
    }
}
