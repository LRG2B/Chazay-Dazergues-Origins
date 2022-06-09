using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSpecificScene : MonoBehaviour
{
    //Permet de récupérer l'index du level en cours

    //SceneManagment.GetActiveScene = new int (y);
    //int y = SceneManager.GetActiveScene().buildIndex;

    //Permet de charger une scène d'après une certaine donnée



    public string SceneName;

    public GameObject loadingScreen;

    public Slider slider;


    //A rajouter + tard
    //public Animator FadeSystem;

    // Start is called before the first frame update
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //PlayerController.instance.currentLifePoints == 100;
    //    //Si le joueur entre en contact avec quelque chose
    //    if (collision.CompareTag("Player"))
    //    {
    //        StartCoroutine(loadNextScene());
    //    }
    //}

    //public IEnumerator loadNextScene()
    //{
    //    //FadeSystem.SetTrigger("FadeIn");
    //    yield return new WaitForSeconds(0.5f);
    //    //Chargement d'après la valeur prise du Build Settings
    //    //Méthode différente : Résultat identique
    //    //SceneManager.LoadScene("Level02");
    //    SceneManager.LoadSceneAsync(SceneName);
    //}
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