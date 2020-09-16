using System;
using UnityEngine;
using UnityEngine.Playables;

public class NextSceneScript : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _director.Play();
        }
    }
}
