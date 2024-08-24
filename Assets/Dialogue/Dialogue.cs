using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    AudioSource mainAudio;
    [SerializeField] private GameObject canvas;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private string dialogueLine;
    [SerializeField] private float showSpeed;

    private void Start()
    {
        mainAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mainAudio.Play();
            canvas.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(StartDialogue());
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
}
