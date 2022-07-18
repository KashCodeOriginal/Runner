using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public event UnityAction<int> PlayerTryToByItem;

    [SerializeField] private Player _player;

    [SerializeField] private GameObject _item;
    
    [SerializeField] private List<ShopItem> _shopItems = new List<ShopItem>();

    [SerializeField] private int _currentItem;

    [SerializeField] private TMP_Text _itemCost;
    
    [SerializeField] private TMP_Text _infoText;

    [SerializeField] private TMP_Text _ammountItemOfPlayerHas;

    private void Start()
    {
        _currentItem = 0;
        SwitchItem(_currentItem);
    }

    public void SwitchItem(int value)
    {
        if (_currentItem >= _shopItems.Count - 1 && value != -1)
        {
            _currentItem = 0;
        }
        else if (_currentItem == 0 && value != 1)
        {
            _currentItem = _shopItems.Count - 1;
        }
        else
        {
            _currentItem += value;
        }
        _item.GetComponent<Image>().sprite = _shopItems[_currentItem]._icon;
        _itemCost.text = _shopItems[_currentItem]._price.ToString();
        _infoText.text = _shopItems[_currentItem]._description;
        _ammountItemOfPlayerHas.text = _shopItems[_currentItem]._amountOfItemPlayerHas.ToString();
    }

    public void TryBuyItem()
    {
        PlayerTryToByItem?.Invoke(_shopItems[_currentItem]._price);
    }

    private void OnEnable()
    {
        _player.PlayerCanBuyItem += BuyItem;
    }
    private void OnDisable()
    {
        _player.PlayerCanBuyItem -= BuyItem;
    }

    private void BuyItem()
    {
        _shopItems[_currentItem]._amountOfItemPlayerHas++;
        _ammountItemOfPlayerHas.text = _shopItems[_currentItem]._amountOfItemPlayerHas.ToString();
    }
}
