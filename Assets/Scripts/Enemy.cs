using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public ParticleSystem hitParticles;
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private float enemyDamage;
    [SerializeField] private float health = 50;
    private AudioSource audioSource;
    private float speed = 2;

    public UnityEvent onDamaged;
    public UnityEvent onDeath;

    private Transform target;
    private bool isReady = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (target != null)
        {
            animator.SetBool("IsRun", true);
        }
        if (isReady == false)
        {
            speed = 0;
        }
        else speed = 2;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, 
        Quaternion.LookRotation(target.position - transform.position), 
        10 * Time.deltaTime);
        
        float yRotation = transform.eulerAngles.y;
        transform.eulerAngles = new Vector3(0, yRotation, 0);
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);

    }

    private void OnTriggerStay(Collider other)
    {
        if (isReady == true && other.TryGetComponent<Player>(out Player player))
        {
            print("ок ез ез");
            player.GetPlayerDamage(enemyDamage);
            StartCoroutine(StartCooldown());
        }
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        hitParticles.Play();
        onDamaged?.Invoke();


        if (health <= 0)
        {
            onDeath?.Invoke();
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            audioSource.Play();
        }
    }

    private IEnumerator StartCooldown()
    {
        isReady = false;
        yield return new WaitForSeconds(2);
        isReady = true;
    }
    

}
