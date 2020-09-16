using UnityEngine;
using UnityEngine.Playables;
using UtilityScripts;

public class NextSceneScript : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;

    [SerializeField] private int killCount;
    [SerializeField] private int killLimitForLevel;

    [SerializeField] private BoxCollider exitBox;

    public static event ResetTheLevel ResetLevel;
    // Start is called before the first frame update
    private void Start()
    {
        exitBox.enabled = false;
        PlayerScript.IncreaseKillCount += IncreaseKillCount;
    }

    private void OnDestroy()
    {
        PlayerScript.IncreaseKillCount -= IncreaseKillCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _director.Play();
        }
    }

    private void IncreaseKillCount()
    {
        killCount++;
        if (killCount >= killLimitForLevel)
        {
            exitBox.enabled = true;
            ResetLevel?.Invoke(false);
        }
    }
}
