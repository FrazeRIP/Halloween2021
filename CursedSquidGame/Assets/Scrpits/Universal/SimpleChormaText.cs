using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleChormaText : MonoBehaviour
{
    Text text;

    void Start()
    {
        text =GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.color = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, .5f));
    }
}
