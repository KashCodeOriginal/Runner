using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinCost;
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent(out Player player))
        {
            player.AddCoin(_coinCost);
            Hide();
        }
    }
    private void Hide()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
