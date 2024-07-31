using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource _source;

    protected override void Awake()
    {
        base.Awake();
        if (_source == null)
        {
            _source = new AudioSource();
        }
        _source = GetComponent<AudioSource>();
    }
    
    public void PlaySoundEffect(AudioClip clip)
    {
        if (clip == null) return;

        if (_source == null) return;
        
        _source.clip = clip;
        _source.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip, bool isLooped, GameObject targetSource)
    {
        if (clip == null)  return;

        AudioSource source = targetSource.GetComponent<AudioSource>();

        if (source == null) return;

        source.clip = clip;
        source.loop = isLooped;
        source.Play();
    }
}
