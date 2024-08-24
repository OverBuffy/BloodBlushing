using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private AudioSource dialogueAudio;
    [SerializeField] private GameObject canvas;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private string dialogueLine;
    [SerializeField] private float showSpeed;

    [SerializeField] private AudioSource mainMusic;
    [SerializeField] private AudioSource backgroundMusic;

    private void Start()
    {
        dialogueAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueAudio.Play();
            canvas.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(StartDialogue());
            mainMusic.Stop();

            if(backgroundMusic != null) backgroundMusic.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(dialogueText.text == dialogueLine) dialogueAudio.Stop();
    }

    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
        mainMusic.Play();
        if(backgroundMusic!= null) backgroundMusic.Stop();
    }

    public IEnumerator StartDialogue()
    {

        dialogueText.text = string.Empty;

        foreach(char c in dialogueLine)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(showSpeed); 
        }
    }
}
