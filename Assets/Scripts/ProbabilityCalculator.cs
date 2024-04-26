using UnityEngine;

public class ProbabilityCalculator : MonoBehaviour
{
    private const float MaxProbability = 100.0f;

    private float _probability = 100.0f;
    private bool _isDeviding;

    public bool IsDeviding => _isDeviding;
    public float Probability => _probability;

    public void SetProbability(float probability)
    {
        _probability = probability;
    }

    public void IsDevide()
    {
        float halving = 0.5f;

        _isDeviding = Random.Range(0, MaxProbability) < _probability;

        _probability *= halving;
    }
}