using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public Camera mainCamera;

    [SerializeField] Image indicator;
    [SerializeField] Slider slider;
    [SerializeField] Animator camAnim;
    [SerializeField] Text timer;
    [SerializeField] float moveSpeed = 1.0f;



    [Header("Debug")]
    public bool canMove;

    public float timeRemaining = 105f;

    float _initialZoom;
    public float InitialZoom { get { return _initialZoom; } }


    private static Movement _instance;

    public static Movement Instance { get { return _instance; } }


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


    void Start()
    {
        _initialZoom = mainCamera.orthographicSize;
        RobotScanner.Instance.Do321();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeIndicator();

        if (mainCamera.orthographicSize>1 &&Input.GetKey(KeyCode.Space))
        {
            SimpleSceneSwitch.Instance.sceneName = "GameOver";
            if (canMove)
            {
                camAnim.Play("camMovement");
                mainCamera.orthographicSize -= Time.deltaTime * moveSpeed;
            }
            else
            {
                Debug.Log("You already dead.");
                Dead();
            }
        }

        if (mainCamera.orthographicSize <= 1 || Input.GetKeyDown(KeyCode.Alpha0))
        {
            SimpleSceneSwitch.Instance.sceneName = "Victory";
            SimpleSceneSwitch.Instance.ChangeScene();
        }

        ChangeProgress();
        Timer();
    }

    void ChangeIndicator()
    {
        if (mainCamera.orthographicSize <= 3)
        {
            indicator.gameObject.SetActive(false);
        }
        else
        {
            if (canMove)
            {
                indicator.color = Color.green;
            }
            else
            {
                indicator.color = Color.red;
            }
        }
    }

    void ChangeProgress()
    {
        slider.value = 1 / mainCamera.orthographicSize;
    }


    public void Dead()
    {
        camAnim.Play("camDead");
        RobotScanner.Instance.Dead();
        Destroy(gameObject);
    }


    void Timer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = Mathf.FloorToInt(timeRemaining % 60);
            timer.text = minutes + ":" + seconds;
        }
        else
        {
            Dead();
        }
    }
}
