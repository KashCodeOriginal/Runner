using UnityEngine;

public class GameValuesChanger : MonoBehaviour
{
    [SerializeField] private float _decreaseStep;
    
    [SerializeField] private float _minTimeBetweenEnemiesValue;
    [SerializeField] private float _minInactiveTimeValue;

    private float _totalPassedTime = 0;
    private void Update()
    {
        _totalPassedTime += Time.deltaTime;
    }
    public void TryDecreaseEnemiesValue(ref float value)
    {
        if (value >= _minTimeBetweenEnemiesValue)
            value -= (_totalPassedTime * _decreaseStep) / 10000;
    }
    public void TryDecreaseInactiveValue(ref float value)
    {
        if (value >= _minInactiveTimeValue)
            value -= (_totalPassedTime * _decreaseStep) / 10000;
    }
}
