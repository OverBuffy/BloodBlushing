using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    AudioSource audioMain;
    [SerializeField] private float playerHealth = 200;
    [SerializeField] private float playerMaxhealth;
    [SerializeField] private Slider playerHealthSlider;
    [SerializeField] private TextMeshProUGUI healthText;

    public UnityEvent onDeath, onAttacked;


    private void Start()
    {
        playerHealth = playerMaxhealth;
        audioMain = GetComponent<AudioSource>();
        playerHealthSlider.maxValue = playerMaxhealth;
        playerHealthSlider.value = playerHealth;
    }

    public void GetPlayerDamage(float damage)
    {
        audioMain.Play();
        playerHealth -= damage;

        playerHealthSlider.value = playerHealth;
        healthText.text = $"HEALTH: {playerHealth}/{playerMaxhealth}";

        onAttacked?.Invoke();

        if (playerHealth <= 0)
        {
            onDeath?.Invoke();
        }
    }
}
