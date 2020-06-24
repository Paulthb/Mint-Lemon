using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerIntro : MonoBehaviour
{
    #region Singleton Pattern
    private static SoundManagerIntro _instance;

    public static SoundManagerIntro Instance { get { return _instance; } }
    #endregion

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);

        else
            _instance = this;
    }

    [SerializeField]
    private AudioClip MusicIntro = null;
    [SerializeField]
    private AudioSource mainSource = null;


    // Start is called before the first frame update
    void Start()
    {

    }

}
