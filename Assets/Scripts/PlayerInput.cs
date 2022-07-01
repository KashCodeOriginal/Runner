using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _playerMover;
    private void Start()
    {
        _playerMover = gameObject.GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if()
    }
}
