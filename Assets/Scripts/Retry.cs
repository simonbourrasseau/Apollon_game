using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter()
    {
        SceneManager.LoadScene(sceneName);
    }
}
