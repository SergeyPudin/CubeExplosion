using UnityEngine;

public class ProbabilityDividingCubes : MonoBehaviour
{
    private float _probability = 1.0f;
    private bool _isDeviding;

    public bool IsDeviding => _isDeviding;

    public void IsDevide()
    {
        float halving = 0.5f;
       
        _isDeviding = Random.value < _probability ? true : false;
        _probability *= halving;
    }
}