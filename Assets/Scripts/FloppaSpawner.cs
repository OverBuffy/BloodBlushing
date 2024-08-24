using UnityEngine;

public class FloppaSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] positions;
    [SerializeField] private GameObject floppaPrefab;

    private FloppaCounter floppaCounter;

    private bool isFirst = true;
    private void Start()
    {
        floppaCounter = GetComponent<FloppaCounter>();
    }

    public void SpawnFloppas()
    {
        if (isFirst == true) 
        {
            for (int i = 0; i < positions.Length; i++)
            {
                GameObject spawnedFloppa = Instantiate(floppaPrefab, positions[i]);
                spawnedFloppa.GetComponent<Enemy>().onDeath.
                    AddListener(floppaCounter.AddDeadFloppa);

            }
            isFirst = false;
            GetComponent<AudioSource>().Play();
        }
        
    }
}
