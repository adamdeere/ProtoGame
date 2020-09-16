using System;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public static event Action<string> OnPlayMusic = delegate { };
    public static event Action<string> OnStopMusic = delegate { };
    public void PlaySoundMusic(string sound)
    {
        OnPlayMusic(sound);
    }
    public void StopSoundMusic(string sound)
    {
        OnStopMusic(sound);
    }
}
