using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameManager GameManager;



    public void ClickPlay()
    {
        SceneManager.LoadScene("Game");
    }
    public void CloseGame()
    {
        Application.Quit();

    }
    public void ResumeGame()
    {
        Debug.Log("Hola");
        GameManager.ReenableControls();
    }
    public void ClickMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
