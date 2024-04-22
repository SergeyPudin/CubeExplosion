using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _explosionForceCoefficient;

    public void SetCoeffisient(float explosionCoefficient)
    {
        _explosionForceCoefficient = explosionCoefficient;
    }
}