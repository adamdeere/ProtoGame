using System;
using UnityEngine;
using UnityEngine.Playables;
using UtilityScripts;

public class ActivateLevel : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private PlayMusic playMusicScript;
    [SerializeField] private BoxCollider collider;
    public static event Action<bool> OnActivateLevel = delegate { };
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<IPlayer>();
        if (player == null) return;
        
        Destroy(collider);
        playMusicScript.PlaySoundMusic("level");
        OnActivateLevel(true);
        director.Play();
        
    }
}
