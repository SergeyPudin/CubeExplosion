using System.Collections.Generic;
using UnityEngine;

public class ExplosionGenerator : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _explosionPrefab;

    private List<Rigidbody> _explosibleCubes = new List<Rigidbody>();

    public void AddNewBorneCube(Rigidbody cube)
    {
        _explosibleCubes.Add(cube);
    }

    public void ExploseNewBornCubes()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

        foreach (Rigidbody cube in _explosibleCubes)
        {
            cube.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    public void ExplodeAllCubes(float explosionCoefficient)
    {
        float explosionForce = _explosionForce * explosionCoefficient;
        float explosionRadius = _explosionRadius * explosionCoefficient;

        Debug.Log(explosionForce);

        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);

        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody)
                hit.attachedRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }
    }
}
