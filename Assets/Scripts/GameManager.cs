using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startToMoveObject = null;
    [SerializeField]
    private GameObject gameOverText = null;

    #region Singleton Pattern
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }
    #endregion

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
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //hide the text at the start of the game
    public void PlayerHasMove()
    {
        startToMoveObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
    }
}
