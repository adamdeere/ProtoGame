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

    private BoxCollider _exitBox;

    public static event ResetTheLevel ResetLevel;
    // Start is called before the first frame update
    private void Start()
    {
        _exitBox = GetComponent<BoxCollider>();

        if (!isEntryDoor) return;
        
        _exitBox.enabled = false;
        PlayerScript.IncreaseKillCount += IncreaseKillCount;
    }

    private void OnDestroy()
    {
        if (isEntryDoor)
            PlayerScript.IncreaseKillCount -= IncreaseKillCount;
      
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<IPlayer>();
        if (player != null)
        {
            director.Play();
            camObject.SetActive(true);
        }
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
        camObject.SetActive(false);
        johnObject.SetActive(false);
    }

    public void AnimationStatered()
    {
        camObject.SetActive(true);
        johnObject.SetActive(true);
    }
}
