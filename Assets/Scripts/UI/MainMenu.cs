using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private float waitTime = 1f;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
        Debug.Log("Moving to next scene");
    }

    IEnumerator StartGameCoroutine()
    {
        source.PlayOneShot(clip);

        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(1);
    }
}
