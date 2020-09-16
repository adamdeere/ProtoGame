using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroClickManager : MonoBehaviour
{
   [SerializeField] private string _sceneName;
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
      //SceneManager.LoadSceneAsync(nextLevelName, LoadSceneMode.Additive);
      StartCoroutine(LoadNextScene(nextLevelName));
   }

   public void UnloadLast(string sceneName)
   {
      SceneManager.UnloadSceneAsync(sceneName);
   }
   IEnumerator SceneSwitch()
   {
      AsyncOperation loadOne = SceneManager.LoadSceneAsync("MainGameSceneDup", LoadSceneMode.Additive);
      yield return loadOne;
      
      AsyncOperation loadTwo = SceneManager.LoadSceneAsync("FirstLevelReal", LoadSceneMode.Additive);
      yield return loadTwo;
    
      //yield return unload;
      
      SceneManager.UnloadSceneAsync(_sceneName);
   }
   
   IEnumerator LoadNextScene(string level)
   {
      
      AsyncOperation loadTwo = SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
      yield return loadTwo;
   }
}