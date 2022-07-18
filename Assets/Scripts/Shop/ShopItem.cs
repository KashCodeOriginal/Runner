using UnityEngine;

[CreateAssetMenu(fileName = "ShopMenu", menuName = "ScriptableObject/Shop Item", order = 1)]
public class ShopItem : ScriptableObject
{
    public string _name;
    public int _price;
    public string _description;
    public Sprite _icon;
    public int _amountOfItemPlayerHas;
}
