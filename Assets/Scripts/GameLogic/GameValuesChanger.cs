using UnityEngine;

public class GameValuesChanger : MonoBehaviour
{
    private float _totalPassedTime = 0;
    private void Update()
    {
        _totalPassedTime += Time.deltaTime;
    }
    public void TryDecreaseValue(ref float value, float minValue, float decreaseStep)
    {
        if (value >= minValue)
            value -= decreaseStep;
    }
}
