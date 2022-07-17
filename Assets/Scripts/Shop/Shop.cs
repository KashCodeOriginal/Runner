using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _item;
    
    [SerializeField] private List<ShopItem> _shopItems = new List<ShopItem>();

    [SerializeField] private int _currentItem;

    [SerializeField] private TMP_Text _itemCost;
    
    [SerializeField] private TMP_Text _infoText;

    private void Start()
    {
        SwitchItem(_currentItem);
    }

    public void SwitchItem(int value)
    {
        if (_currentItem >= _shopItems.Count - 1 && value != -1)
        {
            _currentItem = 0;
        }
        else if (_currentItem <= 0 && value != 1)
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
    }
}
