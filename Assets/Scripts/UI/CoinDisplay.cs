using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _coinsText;

    private void OnEnable()
    {
        _player.PlayerCoinsChanged += AddCoin;
    }
    private void OnDisable()
    {
        _player.PlayerCoinsChanged -= AddCoin;
    }
    private void AddCoin(int coins)
    {
        _coinsText.text = "Coins: " + coins;
    }
}
