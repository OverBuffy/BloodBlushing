using System.Collections;
using UnityEngine;

public class LastDialogue : MonoBehaviour
{
    private Dialogue dialogue;
    private Animator animator;

    [SerializeField] private AudioSource mainMusic;
    [SerializeField] private GameObject scaryWalter;
    [SerializeField] private Enemy walterEnemy;
    [SerializeField] private Animator walterAnimator;
    [SerializeField] private AudioSource bossAppearSound;

    private void Awake()
    {
        dialogue = GetComponent<Dialogue>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(StartLastDialogue());
    }

    private IEnumerator StartLastDialogue()
    {
        mainMusic.Stop();

        dialogue.StartDialogueVoid();
        yield return new WaitForSeconds(16);

        dialogue.StopDialogueVoid();
        animator.SetTrigger("isFalling");
        yield return new WaitForSeconds(3);

        scaryWalter.SetActive(true);
        mainMusic.Stop();
        walterEnemy.isReady = false;
        walterAnimator.SetBool("IsAppearing", true);
        bossAppearSound.Play();
        

        yield return new WaitForSeconds(6);

        walterAnimator.SetBool("IsAppearing", false);
        walterEnemy.isReady = true;
        mainMusic.Play();

    }
}
