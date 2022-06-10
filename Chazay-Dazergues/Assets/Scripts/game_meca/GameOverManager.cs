using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public GameObject GameOverUI;

    public string MainMenuLoad;

    //instance
    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    //Quand le joueur est mort !
    public void OnPlayerDeath()
    {
        //On active le menu (on le fait appara�tre)
        GameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        //Recharger la sc�ne
        //On recharge le niveau via le buildIndex (pour savoir quel niveau nous int�resse)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameOverUI.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(MainMenuLoad);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
