using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _heartPrefab;

    [SerializeField] private List<GameObject> _hearts = new List<GameObject>();
    
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
        if (_hearts.Count < health)
        {
            int _currentCreatableHealthCount = health - _hearts.Count;
            for (int i = 0; i < _currentCreatableHealthCount; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > health)
        {
            int _currentDeletableHealthCount = _hearts.Count - health;
            for (int i = 0; i < _currentDeletableHealthCount; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void CreateHeart()
    {
        GameObject heart = Instantiate(_heartPrefab, new Vector3(0, 0, 0), Quaternion.identity, transform);
        _hearts.Add(heart);
    }

    private void DestroyHeart(GameObject gameObject)
    {
        Destroy(gameObject);
        gameObject.toE
    }
}
