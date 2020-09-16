using System;
using UnityEngine;

public class PlaySoundEffect : MonoBehaviour
{
    public static event Action<string> OnPlaySoundEffect = delegate { };
    public static event Action<string> OnStopSoundEffect = delegate { };
    
    public void PlaySoundEffectFunction(string sound)
    {
        OnPlaySoundEffect(sound);
    }
    public void StopSoundEffectFunction(string sound)
    {
        OnStopSoundEffect(sound);
    }
}
