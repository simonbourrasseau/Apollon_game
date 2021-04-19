
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter()
    {
            SceneManager.LoadScene(sceneName);
    }

}
 