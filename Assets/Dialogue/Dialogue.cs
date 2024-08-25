using System.Collections;
using System.Xml.Serialization;
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
        if (dialogueText.text == dialogueLine)
        {
            dialogueAudio.Stop();
            mainMusic.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueAudio.Stop();
            canvas.SetActive(false);
            mainMusic.Play();
            if(backgroundMusic!= null) backgroundMusic.Stop();
            StopAllCoroutines();
        }

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

    public void StartDialogueVoid()
    {
        dialogueAudio.Play();
        canvas.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(StartDialogue());
        mainMusic.Stop();

        if (backgroundMusic != null) backgroundMusic.Play();
    }
    public void StopDialogueVoid()
    {
        dialogueAudio.Stop();
        canvas.SetActive(false);
        mainMusic.Play();
        if (backgroundMusic != null) backgroundMusic.Stop();
        StopAllCoroutines();
    }
}
