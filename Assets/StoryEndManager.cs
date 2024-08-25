using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryEndManager : MonoBehaviour
{

    public void StartGoodEnding()
    {
        SceneManager.LoadScene(9);
    }
    public void StartBadEnding()
    {
        SceneManager.LoadScene(8);
    }

}
