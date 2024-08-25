using UnityEngine;

public class FloppaSpawner : MonoBehaviour
{
    [SerializeField] AudioClip dangerOst;
    [SerializeField] private GameObject floppas;
    private bool isFirst = true;

    public void SpawnFloppas()
    {
        if (isFirst == true) 
        {
            floppas.SetActive(true);
            GetComponent<AudioSource>().clip = dangerOst;
            GetComponent<AudioSource>().Play();
            isFirst = false;
        }

    }
}
