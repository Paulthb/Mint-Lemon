using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormScript : MonoBehaviour
{
    public float smooth = 1f;
    private Vector3 targetAngles;

    private bool isTouilletteRunning = false;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.S)) // some condition to rotate 180
        //    StartCoroutine(TouilletteActivate(true));

        //if (Input.GetKeyDown(KeyCode.D)) // some condition to rotate 180
        //    StartCoroutine(TouilletteActivate(false));

        if (isTouilletteRunning)
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, smooth * Time.deltaTime); // lerp to new angles
    }

    public IEnumerator TouilletteActivate(bool isRight)
    {
        isTouilletteRunning = true;

        yield return new WaitForSeconds(0.9f);
        FXManager.Instance.LaunchTouillette();

        //tourne vers la droite ou vers la gauche
        if (isRight)
            targetAngles = transform.eulerAngles + 360f * Vector3.forward; // what the new angles should be
        else
            targetAngles = transform.eulerAngles + 360f * Vector3.back; // what the new angles should be

        float elapsedTime = 0;
        float waitTime = 3.5f;

        float baseSmooth = smooth;
        float maxSmooth = 1;

        while (elapsedTime < waitTime)
        {
            if (elapsedTime < waitTime / 2)
                smooth = Mathf.Lerp(baseSmooth, maxSmooth, (elapsedTime / waitTime));
            else
                smooth = Mathf.Lerp(maxSmooth, baseSmooth, (elapsedTime / waitTime));

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        isTouilletteRunning = false;
        FXManager.Instance.StopTouillette();
    }
}