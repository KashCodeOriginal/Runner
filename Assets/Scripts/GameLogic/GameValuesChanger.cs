using UnityEngine;

public class GameValuesChanger : MonoBehaviour
{
    public void TryDecreaseValue(ref float value, float minValue, float decreaseStep)
    {
        if (value >= minValue)
            value -= decreaseStep;
    }
}
