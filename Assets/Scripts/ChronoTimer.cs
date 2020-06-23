using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChronoTimer : MonoBehaviour
{
    [SerializeField]
    private Text chronoText = null;

    private float timer = 0;

    void Update()
    {
        if (timer >= 0.0f && GameManager.Instance.isGameStarted)
        {
            // Compute remaining time
            timer += Time.deltaTime;

            // Update the timer!
            UpdateTimerContent(timer);
        }
    }

    /**
    * Transforms the timer content into a usable string.
    */
    private void UpdateTimerContent(float timerValue)
    {
        // Extrat timer values
        string timerMinutes = Mathf.Floor(timerValue / 60).ToString("00");
        string timerSeconds = Mathf.Floor(timerValue % 60).ToString("00");
        string timerMilliSeconds = string.Format("{0:F3}", timerValue);

        // Produce the text!
        if (timerMilliSeconds[2].ToString() != ",") //DEGUEU !!!!
        {
            chronoText.text = timerMinutes[0].ToString()
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
            chronoText.text = timerMinutes[0].ToString()
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
    }
}
