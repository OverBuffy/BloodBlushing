using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseLoading : MonoBehaviour
{
    private void Update()
    {
        Invoke("HouseLoad", 8f);
    }
    private void HouseLoad()
    {
        SceneManager.LoadScene(2);
    }
}
