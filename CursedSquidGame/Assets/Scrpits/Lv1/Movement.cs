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

    [SerializeField] float moveSpeed = 1.0f;


    [Header("Debug")]
    public bool canMove;

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

        if (mainCamera.orthographicSize>=1 &&Input.GetKey(KeyCode.Space))
        {
            if (canMove)
            {
                camAnim.Play("camMovement");
                mainCamera.orthographicSize -= Time.deltaTime * moveSpeed;
            }
            else
            {
                Debug.Log("You already dead.");
                Destroy(gameObject);
            }
        }

        ChangeProgress();
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
}
