using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

            //gameOver.SetActive(true);

            GetComponent<ThirdPersonShooterController>().enabled = false;
            GetComponent<PlayerMovementTutorial>().enabled = false;
            //GetComponent<PauseMenu>().enabled = false;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        totalPlayerhealth.text = Mathf.Round(playerHealth).ToString();
    }
}
