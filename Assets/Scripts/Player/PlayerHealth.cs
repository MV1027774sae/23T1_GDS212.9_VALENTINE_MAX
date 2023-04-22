using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    private float playerHealthMax = 100f;
    [SerializeField] private float healthRegen = 1f;

    //public GameObject gameOver;

    public float healthIndicator;
    [SerializeField] private TextMeshProUGUI totalPlayerhealth;

    private void Start()
    {
        playerHealth = playerHealthMax;
    }

    private void Update()
    {
        playerHealth += healthRegen;

        if (playerHealth > 100f)
        {
            playerHealth = playerHealthMax;
        }

        if (playerHealth <= 0f)
        {
            playerHealth = 0f;

            SceneManager.LoadScene(0);
        }

        totalPlayerhealth.text = Mathf.Round(playerHealth).ToString();
    }
}
