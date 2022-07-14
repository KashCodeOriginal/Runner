using UnityEngine;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    [SerializeField] private Button _unmuteSong;

    [SerializeField] private Sprite _muteSprite;
    [SerializeField] private Sprite _unmuteSprite;
    
    [SerializeField] private Button _unmuteSounds;

    [SerializeField] private Sprite _muteSoundSprite;
    [SerializeField] private Sprite _unmuteSoundsSprite;

    [SerializeField] private Image _musicIcon;
    [SerializeField] private Image _soundIcon;
    
    [SerializeField] private AudioSource _audioSource;
    
    public void MuteAudio()
    {
        _audioSource.mute = true;
        _unmuteSong.gameObject.SetActive(true);
        _musicIcon.sprite = _muteSprite;
    }
    public void UnmuteAudio()
    {
        _audioSource.mute = false;
        _unmuteSong.gameObject.SetActive(false);
        _musicIcon.sprite = _unmuteSprite;
    }
    public void MuteSounds()
    {
        _unmuteSounds.gameObject.SetActive(true);
        _soundIcon.sprite = _muteSoundSprite;
    }
    public void UnmuteSounds()
    {
        _unmuteSounds.gameObject.SetActive(false);
        _soundIcon.sprite = _unmuteSoundsSprite;
    }
}
