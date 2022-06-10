using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSpecificScene : MonoBehaviour
{
    //Permet de récupérer l'index du level en cours

    public Button[] levelButtons;

    public string SceneName;

    public GameObject loadingScreen;

    public Slider slider;


    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadLevel(SceneName);
        }
    }

    public void LoadLevel(string SceneName)
    {
        StartCoroutine(LoadAsyncchrononously(SceneName));
    }

    IEnumerator LoadAsyncchrononously (string SceneName)
    {
        //Pour sauvegarder les datas
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);


        //Pour activer le loading screen
        LoadAndSaveData.instance.SaveData();
        loadingScreen.SetActive(true);
            
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }

}