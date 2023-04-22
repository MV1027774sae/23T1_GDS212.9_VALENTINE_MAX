using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    [SerializeField] private GameObject shot1;
    [SerializeField] private GameObject shot2;
    [SerializeField] private GameObject shot3;
    [SerializeField] private GameObject shot4;
    [SerializeField] private GameObject shot5;
    [SerializeField] private GameObject shot6;
    [SerializeField] private GameObject shot7;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip gunShot;

    void Start()
    {
        shot1.SetActive(true);
        shot2.SetActive(false);
        shot3.SetActive(false);
        shot4.SetActive(false);
        shot5.SetActive(false);
        shot6.SetActive(false);
        shot7.SetActive(false);

        StartCoroutine(NextShotOne());
    }

    IEnumerator NextShotOne()
    {
        shot1.SetActive(true);

        yield return new WaitForSeconds(7f);
        StartCoroutine(NextShotTwo());
    }

    IEnumerator NextShotTwo()
    {
        shot2.SetActive(true);
        shot1.SetActive(false);

        yield return new WaitForSeconds(9f);
        StartCoroutine(NextShotThree());
    }

    IEnumerator NextShotThree()
    {
        shot3.SetActive(true);
        shot2.SetActive(false);

        yield return new WaitForSeconds(4.5f);
        StartCoroutine(NextShotFour());
    }

    IEnumerator NextShotFour()
    {
        shot4.SetActive(true);
        shot3.SetActive(false);

        yield return new WaitForSeconds(5f);
        StartCoroutine(NextShotFive());
    }

    IEnumerator NextShotFive()
    {
        shot5.SetActive(true);
        shot4.SetActive(false);

        yield return new WaitForSeconds(7f);
        StartCoroutine(NextShotSix());
    }

    IEnumerator NextShotSix()
    {
        shot6.SetActive(true);
        shot5.SetActive(false);
        source.PlayOneShot(gunShot);
        
        yield return new WaitForSeconds(2.5f);
        NextShotSeven();
    }

    private void NextShotSeven()
    {
        shot7.SetActive(true);
        shot6.SetActive(false);
    }
}
