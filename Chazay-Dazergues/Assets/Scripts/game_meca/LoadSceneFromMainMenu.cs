using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneFromMainMenu : MonoBehaviour
{
    //Permet de récupérer l'index du level en cours

    public Button[] levelButtons;

    public string SceneName;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void LoadLevel(string SceneName)
    {
        StartCoroutine(LoadAsyncchrononously(SceneName));
        LoadAndSaveData.instance.SaveData();
    }

    IEnumerator LoadAsyncchrononously(string SceneName)
    {
        //Pour sauvegarder les datas
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);
        yield return null;
    }

}
