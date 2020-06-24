using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem touillette;


    #region Singleton Pattern
    private static FXManager _instance;

    public static FXManager Instance { get { return _instance; } }
    #endregion

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);

        else
            _instance = this;
    }


    public void LaunchTouillette()
    {
        touillette.Play();
    }

    public void StopTouillette()
    {
        touillette.Stop();
    }
}
