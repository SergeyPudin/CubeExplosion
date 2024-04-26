using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Vector3 _spawnAreaSize;
    [SerializeField] private Vector3 _spawnAreaCenter;

    private void OnDrawGizmosSelected()
    {
        const float Halving = 0.5f;

        Gizmos.color = Color.blue;

        Vector3 corner1 = new Vector3(_spawnAreaCenter.x - _spawnAreaSize.x * Halving, _spawnAreaCenter.y - _spawnAreaSize.y * Halving, _spawnAreaCenter.z - _spawnAreaSize.z * Halving);
        Vector3 corner2 = new Vector3(_spawnAreaCenter.x + _spawnAreaSize.x * Halving, _spawnAreaCenter.y - _spawnAreaSize.y * Halving, _spawnAreaCenter.z - _spawnAreaSize.z * Halving);
        Vector3 corner3 = new Vector3(_spawnAreaCenter.x + _spawnAreaSize.x * Halving, _spawnAreaCenter.y - _spawnAreaSize.y * Halving, _spawnAreaCenter.z + _spawnAreaSize.z * Halving);
        Vector3 corner4 = new Vector3(_spawnAreaCenter.x - _spawnAreaSize.x * Halving, _spawnAreaCenter.y - _spawnAreaSize.y * Halving, _spawnAreaCenter.z + _spawnAreaSize.z * Halving);
        Vector3 corner5 = new Vector3(_spawnAreaCenter.x - _spawnAreaSize.x * Halving, _spawnAreaCenter.y + _spawnAreaSize.y * Halving, _spawnAreaCenter.z - _spawnAreaSize.z * Halving);
        Vector3 corner6 = new Vector3(_spawnAreaCenter.x + _spawnAreaSize.x * Halving, _spawnAreaCenter.y + _spawnAreaSize.y * Halving, _spawnAreaCenter.z - _spawnAreaSize.z * Halving);
        Vector3 corner7 = new Vector3(_spawnAreaCenter.x + _spawnAreaSize.x * Halving, _spawnAreaCenter.y + _spawnAreaSize.y * Halving, _spawnAreaCenter.z + _spawnAreaSize.z * Halving);
        Vector3 corner8 = new Vector3(_spawnAreaCenter.x - _spawnAreaSize.x * Halving, _spawnAreaCenter.y + _spawnAreaSize.y * Halving, _spawnAreaCenter.z + _spawnAreaSize.z * Halving);

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

    public Cube SpawnCube()
    {
        return Instantiate(_cubePrefab, RandomSpawnPosition(), Quaternion.identity);
    }

    private Vector3 RandomSpawnPosition()
    {
        float halving = 0.5f;

        float minValue = 0.5f;
        float maxValue = 1.0f;  

        Vector3 randomPosition;

        float randomX = Random.Range(_spawnAreaCenter.x - _spawnAreaSize.x * halving, _spawnAreaCenter.x + _spawnAreaSize.x * halving);
        float randomY = Mathf.Clamp(Random.Range(_spawnAreaCenter.y - _spawnAreaSize.y * halving, _spawnAreaCenter.y + _spawnAreaSize.y * halving), minValue, maxValue);
        float randomZ = Random.Range(_spawnAreaCenter.z - _spawnAreaSize.z * halving, _spawnAreaCenter.z + _spawnAreaSize.z * halving);

        randomPosition = new Vector3(randomX, randomY, randomZ);

        Vector3 direction = randomPosition - transform.position;     
        Vector3 newPosition = transform.position + direction.normalized;

        return newPosition;
    }
}