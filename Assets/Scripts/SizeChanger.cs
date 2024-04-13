using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    private float _scaleValue;

    private void Awake()
    {
        _scaleValue = transform.localScale.x;
    }

    public void DecreaseSize()
    {
        ChangeScaleValue();

        transform.localScale = new Vector3(_scaleValue, _scaleValue, _scaleValue);
    }

    private void ChangeScaleValue()
    {
        const float Halving = 0.5f;

        _scaleValue *= Halving;
    }
}