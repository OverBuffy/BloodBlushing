using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    public Animator animator;
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
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
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
            agent.speed = 0;
        }
        else agent.speed = 2;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, 
        Quaternion.LookRotation(target.position - transform.position), 
        10 * Time.deltaTime);
        
        float yRotation = transform.eulerAngles.y;
        transform.eulerAngles = new Vector3(0, yRotation, 0);
        agent.destination = target.position;

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
