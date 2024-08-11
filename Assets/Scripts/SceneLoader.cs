using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    public InteractablesManager interactablesManager;

    public void Scene1()
    {
        if (interactablesManager.interactables.Count == 6)
        {
            LoadScene("Cena 2");
        }
    }
    public void Scene2()
    {
        if (interactablesManager.interactables.Count == 3)
        {
            LoadScene("Cena 3");
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