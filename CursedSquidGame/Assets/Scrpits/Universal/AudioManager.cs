using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] _victoryClips;
    public AudioClip VictoryClip { get { return _victoryClips[Random.Range(0, _victoryClips.Length)]; } }

    [SerializeField] AudioClip[] _gameOverClips;
    public AudioClip GameOverClip { get { return _gameOverClips[Random.Range(0, _gameOverClips.Length)]; } }

    [SerializeField] AudioClip[] _hurtClips;
    public AudioClip HurtClip { get { return _hurtClips[Random.Range(0, _hurtClips.Length)]; } }

    [SerializeField] AudioClip[] _bgmClips;
    public AudioClip BGMClip { get { return _bgmClips[Random.Range(0, _bgmClips.Length)]; } }



    #region Singleton
    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }
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
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion
}
