using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [Header("Main Menu")]
   [SerializeField] private GameObject loadingScreen;
   [SerializeField] private GameObject Menu;

    [Header("Slider")]
   [SerializeField] private Slider fill;

   public void LoadBtn(string levelToLoad){
    Menu.SetActive(false);
    loadingScreen.SetActive(true);

    StartCoroutine(LoadLevel(levelToLoad));

   }

   IEnumerator LoadLevel(string levelToLoad){
    AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

    while(!loadOperation.isDone){
        float value = Mathf.Clamp01(loadOperation.progress/0.9f);
        fill.value = value;
        yield return null;
    }
   }
}
