using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{
    [SerializeField]GameObject[] levelDescriptions;
    SimpleSceneSwitch SSS;

    // Start is called before the first frame update
    void Start()
    {
        SSS = GetComponent<SimpleSceneSwitch>();
        foreach (GameObject obj in levelDescriptions)
        {
            obj.SetActive(false);
        }
        levelDescriptions[GameManager.Instance.currentLevel - 1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SSS.sceneName = "Lv" + GameManager.Instance.currentLevel;
            SSS.ChangeScene();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SSS.sceneName = "MainMenu";
            SSS.ChangeScene();
        }
    }
}
