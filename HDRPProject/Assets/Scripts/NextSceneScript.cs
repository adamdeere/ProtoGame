using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Serialization;
using UtilityScripts;

public class NextSceneScript : MonoBehaviour
{
    [FormerlySerializedAs("_director")] [SerializeField] private PlayableDirector director;

    private int _killCount;
    [SerializeField] public int killLimitForLevel;
    [SerializeField] public bool isEntryDoor;
    [SerializeField] private Material openMatt;
    [SerializeField] private GameObject doorObject;
    [SerializeField] private GameObject camObject;
    [SerializeField] private GameObject johnObject;
    [SerializeField] private PlayMusic playMusicScript;

    private BoxCollider _exitBox;

    public static event ResetTheLevel ResetLevel;

    public static event RepositionPlayer ReposPlayer;
    public static event TurnPlayerOff TogglePlayerOff;
    // Start is called before the first frame update
    private void Start()
    {
        _exitBox = GetComponent<BoxCollider>();

        if (!isEntryDoor) return;
        
        ToggleObjects(false);
        _exitBox.enabled = false;
        PlayerScript.IncreaseKillCount += IncreaseKillCount;
        playMusicScript.PlaySoundMusic("level");
        DontDestroyOnLoad(gameObject.transform.parent);
    }

    private void OnDestroy()
    {
        if (isEntryDoor)
            PlayerScript.IncreaseKillCount -= IncreaseKillCount;
      
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<IPlayer>();
        if (player == null) return;
        
        playMusicScript.StopSoundMusic("level");
        ToggleObjects(true);
        TogglePlayerOff?.Invoke();
        director.Play();
    }

    private void ToggleObjects(bool toggle)
    {
        camObject.SetActive(toggle);
        johnObject.SetActive(toggle);
       
    }
    private void IncreaseKillCount()
    {
        if (!isEntryDoor) return;
        _killCount++;
        
        if (_killCount < killLimitForLevel) return;
        
        _exitBox.enabled = true;
        ResetLevel?.Invoke(false);
        doorObject.GetComponent<MeshRenderer>().material = openMatt;

    }

    public void AnimationFinished()
    {
        ReposPlayer?.Invoke(johnObject.transform);
        ToggleObjects(false);
    }

    public void AnimationStatered()
    {
        ToggleObjects(true);
        TogglePlayerOff?.Invoke();
    }
}
