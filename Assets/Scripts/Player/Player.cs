using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _totalCoins;
    [SerializeField] private int _currentCoins;

    [SerializeField] private Sounds _sounds;

    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private TMP_Text _totalCoinsValue;

    [SerializeField] private Shop _shop;

    [SerializeField] private Abilities _abilities;
    
    [SerializeField] private Transform _longObjList;
    [SerializeField] private Transform _enemiesList;

    [SerializeField] private Spawner _spawner;
    
    [SerializeField] private Animator _playerAnimator;

    [SerializeField] private GameObject _sphere;

    private bool _isCoinsDoubled;
    private bool _isPlayerInvulnerability;
    
    private Animator _animator;
    
    public event UnityAction<int> PlayerHealthChanged;
    public event UnityAction<int> PlayerCoinsChanged;

    public event UnityAction PlayerCanBuyItem;
    
    public event UnityAction Died;
    
    private void Start()
    {
        Application.targetFrameRate = 60;
        LoadCoins();
        PlayerHealthChanged?.Invoke(_health);
        _currentCoins = 0;
        PlayerCoinsChanged?.Invoke(_currentCoins);
        _animator = gameObject.GetComponent<Animator>();
        _totalCoinsValue.text = _totalCoins.ToString();
    }

    public void DeleteAllActiveEnemies()
    {
        DeleteEnemy(_enemiesList);
        DeleteEnemy(_longObjList);
        _particleSystem.Play();
        _spawner.enabled = false;
        StartCoroutine(SpawnerOn());
        _sounds.PlayWindSound();
    }

    private void DeleteEnemy(Transform list)
    {
        foreach (Transform obj in list)
        {
            if (obj.gameObject.activeSelf == true && obj.gameObject.GetComponent<Enemy>() == true)
            {
                obj.gameObject.SetActive(false);
            }
        }
    }
    
    public void ApplyDamage(int damage)
    {
        if (_isPlayerInvulnerability == false)
        {
            _health -= damage;
        
            PlayerHealthChanged?.Invoke(_health);
        
            if (_health <= 0)
            {
                Die();
            }
        
            _sounds.PlayHitSound();
        
            DeleteAllActiveEnemies();
            
            _playerAnimator.SetTrigger("Hit");
        }
    }

    public void AddCoin(int amount, bool _isCoinsRewarded)
    {
        if (_isCoinsRewarded == true)
        {
            _totalCoins += amount;
            _totalCoinsValue.text = _totalCoins.ToString();
            return;
        }
        if (_isCoinsDoubled == false)
        {
            _currentCoins += amount;
            _totalCoins += amount;
        }
        else
        {
            _currentCoins += amount * 2;
            _totalCoins += amount * 2;
        }
        
        PlayerCoinsChanged?.Invoke(_currentCoins);

        SaveCoins();
        
        _sounds.PlayCoinCollectSound();
    }

    private void Die()
    {
        _animator.SetBool("PlayerDied", true);
        Died?.Invoke();
    }
    
    private void SaveCoins()
    {
        PlayerPrefs.SetInt("coins",_totalCoins);
    }
    private void LoadCoins()
    {
        _totalCoins = PlayerPrefs.GetInt("coins");
    }

    private void OnEnable()
    {
        _shop.PlayerTryToByItem += TryBuyItem;
        _abilities.PlayerAddHealth += AddHealth;
        _abilities.PlayerDoubleCoins += DoubleScore;
        _abilities.PlayerInvulnerability += PlayerInvulnerability;
    }
    private void OnDisable()
    {
        _shop.PlayerTryToByItem -= TryBuyItem;
        _abilities.PlayerAddHealth -= AddHealth;
        _abilities.PlayerDoubleCoins -= DoubleScore;
        _abilities.PlayerInvulnerability -= PlayerInvulnerability;
    }

    private void TryBuyItem(int itemCost)
    {
        if (_totalCoins >= itemCost)
        {
            PlayerCanBuyItem?.Invoke();
            _totalCoins -= itemCost;
            _totalCoinsValue.text = _totalCoins.ToString();
            SaveCoins();
        }
        else
        {
            _sounds.PlayUnSuccessfulBuySound();
        }
    }

    private void AddHealth(int health)
    {
        _health = health;
        PlayerHealthChanged?.Invoke(_health);
    }
    private void DoubleScore(bool isCoinsDoubled)
    {
        _isCoinsDoubled = isCoinsDoubled;
    }

    private void PlayerInvulnerability(bool isPlayerInvulnerability)
    {
        _isPlayerInvulnerability = isPlayerInvulnerability;
        _sphere.SetActive(true);
        _sphere.GetComponent<Animation>().Play("PlayerShieldRotation");

        if (isPlayerInvulnerability == false)
        {
            _sphere.SetActive(false);
            _sphere.GetComponent<Animation>().Stop("PlayerShieldRotation");
        }
    }

    private IEnumerator SpawnerOn()
    {
        yield return new WaitForSeconds(5f);
        _spawner.enabled = true;
    }
}
