using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Exploder : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private ProbabilityDividingCubes _probabilityDividingCubes;
    [SerializeField] private Vector3 _spawnAreaSize;
    [SerializeField] private Vector3 _spawnAreaCenter;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _explosionPrefab;

    List<Rigidbody> _explosibleCubes = new List<Rigidbody>();
    private Material _material;
    private float _scale;
    private ParticleSystem _currentExplosion;
   
    private void Start()
    {
        _scale = transform.localScale.x;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        Vector3 corner1 = new Vector3(_spawnAreaCenter.x - _spawnAreaSize.x / 2, _spawnAreaCenter.y - _spawnAreaSize.y / 2, _spawnAreaCenter.z - _spawnAreaSize.z / 2);
        Vector3 corner2 = new Vector3(_spawnAreaCenter.x + _spawnAreaSize.x / 2, _spawnAreaCenter.y - _spawnAreaSize.y / 2, _spawnAreaCenter.z - _spawnAreaSize.z / 2);
        Vector3 corner3 = new Vector3(_spawnAreaCenter.x + _spawnAreaSize.x / 2, _spawnAreaCenter.y - _spawnAreaSize.y / 2, _spawnAreaCenter.z + _spawnAreaSize.z / 2);
        Vector3 corner4 = new Vector3(_spawnAreaCenter.x - _spawnAreaSize.x / 2, _spawnAreaCenter.y - _spawnAreaSize.y / 2, _spawnAreaCenter.z + _spawnAreaSize.z / 2);
        Vector3 corner5 = new Vector3(_spawnAreaCenter.x - _spawnAreaSize.x / 2, _spawnAreaCenter.y + _spawnAreaSize.y / 2, _spawnAreaCenter.z - _spawnAreaSize.z / 2);
        Vector3 corner6 = new Vector3(_spawnAreaCenter.x + _spawnAreaSize.x / 2, _spawnAreaCenter.y + _spawnAreaSize.y / 2, _spawnAreaCenter.z - _spawnAreaSize.z / 2);
        Vector3 corner7 = new Vector3(_spawnAreaCenter.x + _spawnAreaSize.x / 2, _spawnAreaCenter.y + _spawnAreaSize.y / 2, _spawnAreaCenter.z + _spawnAreaSize.z / 2);
        Vector3 corner8 = new Vector3(_spawnAreaCenter.x - _spawnAreaSize.x / 2, _spawnAreaCenter.y + _spawnAreaSize.y / 2, _spawnAreaCenter.z + _spawnAreaSize.z / 2);

        Gizmos.DrawLine(corner2, corner3);
        Gizmos.DrawLine(corner3, corner4);
        Gizmos.DrawLine(corner4, corner1);

        Gizmos.DrawLine(corner5, corner6);
        Gizmos.DrawLine(corner6, corner7);
        Gizmos.DrawLine(corner7, corner8);
        Gizmos.DrawLine(corner8, corner5);

        Gizmos.DrawLine(corner1, corner5);
        Gizmos.DrawLine(corner2, corner6);
        Gizmos.DrawLine(corner3, corner7);
        Gizmos.DrawLine(corner4, corner8);
    }

    public void Explode()
    {
        _probabilityDividingCubes.IsDevide();

        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);


        if (_probabilityDividingCubes.IsDeviding)
        {
            SetScale();
            for (int i = 0; i < 2; i++)
            {
                CreateCubes();
            }
        }

        foreach (Rigidbody cube in _explosibleCubes)
        {
            cube.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        Destroy(gameObject);
    }

    public void GetProbability(ProbabilityDividingCubes probability)
    {
        _probabilityDividingCubes = probability;
    }

    private void SetScale()
    {
        float coefficient = 0.5f;

        _scale *= coefficient;
    }

    private Color GetColor()
    {
        int random = Random.Range(0, _colors.Length);

        return _material.color = _colors[random];
    }

    private void CreateCubes()
    {
        Cube cube = Instantiate(_cubePrefab, RandomSpawnPosition(), Quaternion.identity);
        cube.transform.localScale = new Vector3(_scale, _scale, _scale);
        _material = cube.GetComponent<Renderer>().material;
        _material.color = GetColor();
        cube.GetComponent<Exploder>().GetProbability(_probabilityDividingCubes);

        if (cube.TryGetComponent<Collider>(out Collider collider))
        {
            if (collider.attachedRigidbody != null)
            {
                _explosibleCubes.Add(collider.attachedRigidbody);
            }
        }
    }

    private Vector3 RandomSpawnPosition()
    {
        Vector3 randomPosition;

        float randomX = Random.Range(_spawnAreaCenter.x - _spawnAreaSize.x / 2, _spawnAreaCenter.x + _spawnAreaSize.x / 2);
        float randomY = Mathf.Clamp(Random.Range(_spawnAreaCenter.y - _spawnAreaSize.y / 2, _spawnAreaCenter.y + _spawnAreaSize.y / 2), 0.5f, 1);
        float randomZ = Random.Range(_spawnAreaCenter.z - _spawnAreaSize.z / 2, _spawnAreaCenter.z + _spawnAreaSize.z / 2);

        randomPosition = new Vector3(randomX, randomY, randomZ);

        Vector3 direction = randomPosition - transform.position;
        direction = direction.normalized * 1;
        Vector3 newPosition = transform.position + direction;

        return newPosition;
    }
}