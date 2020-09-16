using System;
using UnityEngine;

public class AudioFactory : MonoBehaviour
{
    [SerializeField] private Sound[] soundEffects;
    [SerializeField] private Sound[] levelMusic;

    public static AudioFactory instance;
    void Awake()
    {
        if (instance == null)
        {
            PlaySoundEffect.OnPlaySoundEffect += PlaySound;
            PlaySoundEffect.OnStopSoundEffect += StopSound;
            PlayMusic.OnPlayMusic += PlayMusicFunction;
            PlayMusic.OnStopMusic += StopMusicFunction;
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
        PopulateSoundArray(soundEffects);
        PopulateSoundArray(levelMusic);
    }

    private void OnDestroy()
    {
        PlaySoundEffect.OnPlaySoundEffect -= PlaySound;
        PlaySoundEffect.OnStopSoundEffect -= StopSound;
        PlayMusic.OnPlayMusic -= PlayMusicFunction;
        PlayMusic.OnStopMusic -= StopMusicFunction;
    }

    private void PlaySound(string soundName)
    {
        var s = Array.Find(soundEffects, sound => sound.name == soundName);
        s?.source.Play();

    }

    private void StopSound(string soundName)
    {
        var s = Array.Find(soundEffects, sound => sound.name == soundName);
        s?.source.Stop();

    }
    private void PlayMusicFunction(string soundName)
    {
        var s = Array.Find(levelMusic, sound => sound.name == soundName);
        if (s != null)
            s.source.Play();
        else
            return;
    }

    private void StopMusicFunction(string soundName)
    {
        var s = Array.Find(levelMusic, sound => sound.name == soundName);
        s?.source.Stop();

    }
    private void PopulateSoundArray(Sound[] soundObjects)
    {
        foreach (Sound s in soundObjects)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.looping;
            s.source.playOnAwake = s.playAwake;
        }
    }
}
[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0,1)]
    public float volume;
    [Range(.1f, 3)]
    public float pitch;
    [HideInInspector]
    public AudioSource source;
    public bool looping;
    public bool playAwake;
}
