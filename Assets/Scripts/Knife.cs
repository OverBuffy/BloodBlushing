using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private float knifeDamage;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.hitParticles.transform.position = transform.position;
            audioSource.Play();
            enemy.GetDamage(knifeDamage);
        }
    }
}
