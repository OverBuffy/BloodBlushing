using System.Collections;
using UnityEngine;

public class LastDialogue : MonoBehaviour
{
    private Dialogue dialogue;
    private Animator animator;

    [SerializeField] private GameObject scaryWalter;
    [SerializeField] private Enemy walterEnemy;
    [SerializeField] private Animator walterAnimator;

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
        dialogue.StartDialogueVoid();
        yield return new WaitForSeconds(16);

        dialogue.StopDialogueVoid();
        animator.SetTrigger("isFalling");
        yield return new WaitForSeconds(3);

        scaryWalter.SetActive(true);
        walterEnemy.isReady = false;
        walterAnimator.SetBool("IsAppearing", true);

        yield return new WaitForSeconds(6);

        walterAnimator.SetBool("IsAppearing", false);
        walterEnemy.isReady = true;

    }
}
