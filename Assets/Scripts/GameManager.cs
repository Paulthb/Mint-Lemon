using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startToMoveObject = null;
    [SerializeField]
    private GameObject gameOverText = null;

    [SerializeField]
    private HighScore highScoreData = null;

    [SerializeField]
    private Transform cameraTransform = null;

    [SerializeField]
    private Transform highScoreCameraPos = null;

    [NonSerialized]
    public bool isGameStarted = false;

    private float timerScore = 0;

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

    //hide the text at the start of the game
    public void PlayerHasMove()
    {
        startToMoveObject.SetActive(false);
        isGameStarted = true;
    }

    public void GameOver()
    {
        isGameStarted = false;
        gameOverText.SetActive(true);

        timerScore = ChronoTimer.Instance.GetTimer();

        highScoreData.scoreList.Add(timerScore);

        StartCoroutine(SwitchToHighScorePlan());
    }

    public IEnumerator SwitchToHighScorePlan()
    {
        yield return new WaitForSeconds(2f);

        float elapsedTime = 0;
        float waitTime = 2f;

        Vector3 baseCamPos = cameraTransform.position;

        while (elapsedTime < waitTime)
        {
            cameraTransform.position = Vector3.Lerp(baseCamPos, highScoreCameraPos.position, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        cameraTransform.position = highScoreCameraPos.position;
    }
}
