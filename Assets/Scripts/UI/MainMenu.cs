using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private float waitTime = 0.8f;

    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
        Debug.Log("Moving to next scene");
    }

    IEnumerator StartGameCoroutine()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(1);
    }
}
