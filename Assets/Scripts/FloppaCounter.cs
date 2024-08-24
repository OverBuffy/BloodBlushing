using UnityEngine;
public class FloppaCounter : MonoBehaviour
{
    [SerializeField] private float requiredFloppas, currentFloppas;
    [SerializeField] private GameObject door;

    public void AddDeadFloppa()
    {
        currentFloppas++;
        if(currentFloppas >= requiredFloppas )
        {
            door.SetActive(true);
        }
    }
}
