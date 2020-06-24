using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton Pattern
    private static SoundManager _instance;

    public static SoundManager Instance { get { return _instance; } }
    #endregion

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);

        else
            _instance = this;
    }


    [SerializeField]
    private AudioSource mainSfxSource = null;
    [SerializeField]
    private AudioClip touilletteSfx = null;
    [SerializeField]
    private AudioClip DeathSfx = null;

    public void PlayDeath()
    {
        mainSfxSource.clip = DeathSfx;
        mainSfxSource.Play();
    }

    public void PlayTouillette()
    {
        mainSfxSource.clip = touilletteSfx;
        mainSfxSource.Play();
    }
}