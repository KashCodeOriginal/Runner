using UnityEngine;

public class GameValuesChanger : MonoBehaviour
{
    [SerializeField] private float _decreaseStep;
    
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;
    
    private float _totalPassedTime = 0;
    private void Update()
    {
        _totalPassedTime += Time.deltaTime;
    }
    public void TryDecreaseValue(ref float value)
    {
        if (value >= minValue)
            value -= (_totalPassedTime * _decreaseStep) / 10000;
    }
    public void TryIncreaseValue(ref float value)
    {
        if (value <= maxValue)
            value += (_totalPassedTime * _decreaseStep) / 10000;
    }
}
