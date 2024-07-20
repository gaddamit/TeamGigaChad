using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource _source;

    public override void Awake()
    {
        base.Awake();
        _source = GetComponent<AudioSource>();
        
    }
    
    public void PlaySoundEffect(AudioClip clip)
    {
        if (clip == null) return;

        if (_source == null) return;
        
        _source.clip = clip;
        _source.PlayOneShot(clip);
    }

    public void PlayLoopedSound(AudioClip clip, float soundDuration, bool isLooped)
    {
        if (clip == null) return;

        if (_source == null) return;

        _source.clip = clip;
        _source.loop = isLooped;
        _source.Play();

        if (_source.isPlaying)
        {
            soundDuration -= Time.fixedDeltaTime;
            
            if (soundDuration <= 0f)
                _source.Stop();
        }
    }

    public void PlayMusic(AudioClip clip, GameObject sourceObject, bool isLooped)
    {
        if (clip == null)  return;

        AudioSource source = sourceObject.GetComponent<AudioSource>();

        if (source == null) return;

        _source.clip = clip;
        _source.loop = isLooped;
        _source.Play();
    }
}
