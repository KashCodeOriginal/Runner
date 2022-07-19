using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    
    [SerializeField] private List<AudioClip> _sounds;

    public void MuteSounds()
    {
        _audioSource.mute = true;
    }
    public void UnmuteSounds()
    {
        _audioSource.mute = false;
    }
    public void PlayWindSound()
    {
        SetSound(_sounds[6]);
    }
    public void PlayAbilitiesSound()
    {
        SetSound(_sounds[5]);
    }
    public void PlayUnSuccessfulBuySound()
    {
        SetSound(_sounds[4]);
    }
    public void PlayMenuClickSound()
    {
        SetSound(_sounds[3]);
    }
    public void PlayCoinCollectSound()
    {
        SetSound(_sounds[2]);
    }
    public void PlayHitSound()
    {
        SetSound(_sounds[1]);
    }
    public void PlaySuccessfulBuySound()
    {
        SetSound(_sounds[0]);
    }
    private void SetSound(AudioClip sound)
    {
        _audioSource.clip = sound;
        _audioSource.Play();
    }

}
