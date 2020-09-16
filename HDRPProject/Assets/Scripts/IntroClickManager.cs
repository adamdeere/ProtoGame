using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroClickManager : MonoBehaviour
{
   private string _sceneName;
   [SerializeField] private AudioListener _listener;
   private void Start()
   {
      _sceneName = SceneManager.GetActiveScene().name;
   }

   public void StartClickPressed()
   {
      Destroy(_listener);
      StartCoroutine(SceneSwitch());
   }
   public void LoadClickPressed()
   {
      Destroy(_listener);
      Debug.Log("load button pressed");
   }

   public void LoadNext(string nextLevelName)
   {
      StartCoroutine(LoadNextScene(nextLevelName));
   }
   IEnumerator SceneSwitch()
   {
      AsyncOperation loadOne = SceneManager.LoadSceneAsync("MainGameSceneDup", LoadSceneMode.Additive);
      yield return loadOne;
      
      AsyncOperation loadTwo = SceneManager.LoadSceneAsync("FirstLevelReal", LoadSceneMode.Additive);
      yield return loadTwo;
      
      
      
      AsyncOperation unload =  SceneManager.UnloadSceneAsync(_sceneName);
      //yield return unload;
      
      SceneManager.UnloadSceneAsync(_sceneName);
   }
   
   IEnumerator LoadNextScene(string level)
   {
      
      AsyncOperation loadTwo = SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
      yield return loadTwo;
      
      SceneManager.UnloadSceneAsync(_sceneName);
   }
}