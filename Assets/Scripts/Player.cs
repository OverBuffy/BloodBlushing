using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    AudioSource audioMain;
    private float playerHealth = 200;

    private void Start()
    {
        audioMain = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void GetPlayerDamage(float damage)
    {
        audioMain.Play();
        playerHealth -= damage;
    }
}
