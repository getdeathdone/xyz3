
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReloadEnter : MonoBehaviour
{

    public void Reload()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
