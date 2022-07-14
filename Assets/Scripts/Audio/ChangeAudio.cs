using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAudio : MonoBehaviour
{
    [SerializeField] private int _currentSongId;
    
    [SerializeField] private float _currentSongVolume;

    [SerializeField] private AudioSource _audioSource;
    
    [SerializeField] private List<AudioClip> _audioClips = new List<AudioClip>();

    [SerializeField] private TMP_Text _songText;

    [SerializeField] private Button _nextSong;
    [SerializeField] private Button _previousSong;

    [SerializeField] private Slider _volumeSlider;
    
    private void Start()
    {
        LoadSong();
        _audioSource.clip = _audioClips[_currentSongId];
        _audioSource.Play();
        _audioSource.volume = _currentSongVolume;
        _volumeSlider.value = _currentSongVolume;
        _songText.text = "#" + (_currentSongId + 1);
    }
    void Update()
    {
        if (!_audioSource.isPlaying)
        {
            ChangeTrack(1);
        }
    }

    private void ChangeTrack(int value)
    {
        if (_currentSongId >= _audioClips.Count - 1 && value != -1)
        {
            _currentSongId = 0;
        }
        else if (_currentSongId <= 0 && value != 1)
        {
            _currentSongId = _audioClips.Count - 1;
        }
        else
        {
            _currentSongId += value;
        }
        _audioSource.clip = _audioClips[_currentSongId];
        _audioSource.Play();

        _songText.text = "#" + (_currentSongId + 1);

        SaveSong();
    }

    public void ChangeMusicVolume()
    {
        _audioSource.volume = _volumeSlider.value;
        _currentSongVolume = _audioSource.volume;
        SaveSong();
    }
    public void PlayNextAudio()
    {
        ChangeTrack(1);
    }
    public void PlayPreviousAudio()
    {
        ChangeTrack(-1);
    }
    private void SaveSong()
    {
        PlayerPrefs.SetInt("songID", _currentSongId);
        PlayerPrefs.SetFloat("songVolume", _currentSongVolume);
    }
    private void LoadSong()
    {
        _currentSongId = PlayerPrefs.GetInt("songID");
        _currentSongVolume = PlayerPrefs.GetFloat("songVolume");
    }
}
