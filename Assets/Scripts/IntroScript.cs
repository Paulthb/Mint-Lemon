using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public GameObject pressToPlayText = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            pressToPlayText.SetActive(false);
            StartCoroutine(StartGameCoroutine());
        }
    }

    public IEnumerator StartGameCoroutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameScene");
    }

    public void StartGame(string sceneNameToLoad)
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
