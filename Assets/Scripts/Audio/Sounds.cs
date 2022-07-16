using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    
    [SerializeField] private List<AudioClip> _sounds;

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
