using System;
using UnityEngine;
using TMPro;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _healthText;
    
    private void OnEnable()
    {
        _player.PlayerHealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.PlayerHealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        _healthText.text = health.ToString();
    }
}
