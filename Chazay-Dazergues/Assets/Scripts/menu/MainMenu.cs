using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public string levelSelectionMenu;
    public GameObject GameOverUI;

    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void LevelSelectionGame()
    {
        SceneManager.LoadScene(levelSelectionMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetButton()
    {
        PlayerPrefs.DeleteAll();
    }
}
