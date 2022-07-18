using UnityEngine;

public class AbilitiesInvoke : MonoBehaviour
{
    private Abilities _abilities;

    private void Start()
    {
        _abilities = GameObject.FindObjectOfType<Abilities>();
    }
    public void AddHeartsClick()
    {
        _abilities.AddHearts();
    }
    public void DoubleCoinsClick()
    {
        _abilities.DoubleCoins();
    }
    public void DoubleScoreClick()
    {
        _abilities.DoubleScore();
    }
    public void InvulnerabilityClick()
    {
        _abilities.Invulnerability();
    }
    public void DeleteAllEnemiesClick()
    {
        _abilities.DeleteAllEnemies();
    }
}
