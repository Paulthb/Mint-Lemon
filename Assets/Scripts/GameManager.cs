using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    private Transform normalScoreCameraPos = null;

    [NonSerialized]
    public bool isGameStarted = false;

    private float timerScore = 0;


    [Header("GameOver")]
    [SerializeField]
    public Text chronoHighScore = null;
    [SerializeField]
    public Text chronoScore = null;
    [SerializeField]
    private GameObject gameOverScreen = null;

    [Header("GameOver WIN")]
    [SerializeField]
    public Text chronoHighScoreWin = null;
    [SerializeField]
    private GameObject winScreen = null;

    [Header("ChronoInGame")]
    [SerializeField]
    private GameObject chronoInGame = null;

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
        StartCoroutine(EventManager.Instance.EventTimer());
    }

    public void GameOver()
    {
        isGameStarted = false;
        gameOverText.SetActive(true);

        timerScore = ChronoTimer.Instance.GetTimer();

        if(timerScore > highScoreData.GetHighScore())
            StartCoroutine(SwitchToHighScorePlan());
        else
            StartCoroutine(SwitchToNormalScorePlan());

        chronoInGame.SetActive(false);
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

        winScreen.SetActive(true);
        chronoHighScoreWin.text = ChronoToString(timerScore);

        highScoreData.scoreList.Add(timerScore);
    }

    public IEnumerator SwitchToNormalScorePlan()
    {
        yield return new WaitForSeconds(2f);

        float elapsedTime = 0;
        float waitTime = 2f;

        Vector3 baseCamPos = cameraTransform.position;


        while (elapsedTime < waitTime)
        {
            cameraTransform.position = Vector3.Lerp(baseCamPos, normalScoreCameraPos.position, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        cameraTransform.position = normalScoreCameraPos.position;

        gameOverScreen.SetActive(true);
        chronoHighScore.text = ChronoToString(highScoreData.GetHighScore());
        chronoScore.text = ChronoToString(timerScore);

        highScoreData.scoreList.Add(timerScore);
    }

    public string ChronoToString(float timerValue)
    {
        string chronoInString;

        // Extrat timer values
        string timerMinutes = Mathf.Floor(timerValue / 60).ToString("00");
        string timerSeconds = Mathf.Floor(timerValue % 60).ToString("00");
        string timerMilliSeconds = string.Format("{0:F3}", timerValue);

        // Produce the text!
        if (timerMilliSeconds[2].ToString() != ",") //DEGUEU !!!!
        {
            chronoInString = timerMinutes[0].ToString()
                + timerMinutes[1].ToString()
                + ":"
                + timerSeconds[0].ToString()
                + timerSeconds[1].ToString() //exemple affichage : "01:30"

            // Produce the text for the millisecond timer gameObject.
            //chronoText.text += ":"
            + ":"
            + timerMilliSeconds[2].ToString()
            + timerMilliSeconds[3].ToString()
            + timerMilliSeconds[4].ToString();
        }
        else
        {
            chronoInString = timerMinutes[0].ToString()
                + timerMinutes[1].ToString()
                + ":"
                + timerSeconds[0].ToString()
                + timerSeconds[1].ToString() //exemple affichage : "01:30"

            // Produce the text for the millisecond timer gameObject.
            //chronoText.text += ":"
            + ":"
            + timerMilliSeconds[3].ToString()
            + timerMilliSeconds[4].ToString()
            + timerMilliSeconds[5].ToString();
        }

        return chronoInString;
    }
}