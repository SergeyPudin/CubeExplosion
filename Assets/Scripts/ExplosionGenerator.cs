using System.Collections.Generic;
using UnityEngine;

public class ExplosionGenerator : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _explosionPrefab;

    private List<Rigidbody> _explosibleCubes = new List<Rigidbody>();

    public void AddExplosibleCube(Rigidbody cube)
    {
        _explosibleCubes.Add(cube);
    }

    public void Explose()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

        MakeBlastWave();
    }

    public void MakeBlastWave()
    {
        foreach (Rigidbody cube in _explosibleCubes)
        {
            cube.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
