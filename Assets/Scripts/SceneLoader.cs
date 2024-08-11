using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    public InteractablesManager interactablesManager;

    public void NextScene()
    {
        if (interactablesManager.interactables.Count == 3)
        {
            //LoadScene();
        }
    }
    public void LoadScene(string scene)
    {
        this.LoadScene(scene.ToString());
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}