using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRebooter : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
