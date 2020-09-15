using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroClickManager : MonoBehaviour
{
   private string _sceneName;
   private void Start()
   {
      _sceneName = SceneManager.GetActiveScene().name;
   }

   public void StartClickPressed()
   {
      StartCoroutine(SceneSwitch());
   }
   public void LoadClickPressed()
   {
      Debug.Log("load button pressed");
   }
   
   IEnumerator SceneSwitch()
   {
      AsyncOperation loadOne = SceneManager.LoadSceneAsync("MainGameSceneDup", LoadSceneMode.Additive);
      yield return loadOne;
      
      AsyncOperation loadTwo = SceneManager.LoadSceneAsync("FirstLevel", LoadSceneMode.Additive);
      yield return loadTwo;
      
      
      
      AsyncOperation unload =  SceneManager.UnloadSceneAsync(_sceneName);
      //yield return unload;
      
      SceneManager.UnloadSceneAsync(_sceneName);
   }
}