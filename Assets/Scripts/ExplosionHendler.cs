using UnityEngine;

[RequireComponent(typeof(ColorChanger))]
[RequireComponent(typeof(CubeSpawner))]
[RequireComponent (typeof(SizeChanger))]
[RequireComponent(typeof(ProbabilityDividingCubes))]
[RequireComponent(typeof(ExplosionGenerator))]
public class ExplosionHendler : MonoBehaviour
{
    private CubeSpawner _cubeSpawner;
    private ExplosionGenerator _explosionGenerator;

    private ProbabilityDividingCubes _probabilityDividingCubes;
    
    private void Start()
    {
        _cubeSpawner = GetComponent<CubeSpawner>();
        _explosionGenerator = GetComponent<ExplosionGenerator>();
        
        _probabilityDividingCubes = GetComponent<ProbabilityDividingCubes>();
    }
    
    public void Explode()
    {
        int minQuantity = 2;
        int maxQuantity = 6;
        int randomValue = Random.Range(minQuantity, maxQuantity);

        _probabilityDividingCubes.IsDevide();

        if (_probabilityDividingCubes.IsDeviding)
        {
            for (int i = 0; i < randomValue; i++)
            {
                CreateCubes();
            }
        }

        _explosionGenerator.Explose();

        Destroy(gameObject);
    }

    public void UpdateProbability(ProbabilityDividingCubes probability)
    {
        _probabilityDividingCubes = probability;
    }
    
    private void CreateCubes()
    {
        Cube cube = _cubeSpawner.SpawnCube();
       
        cube.GetComponent<ColorChanger>().ChangeColor();        
        cube.GetComponent<SizeChanger>().DecreaseSize();

        cube.GetComponent<ExplosionHendler>().UpdateProbability(_probabilityDividingCubes);
        cube.GetComponent<ProbabilityDividingCubes>().SetProbability(_probabilityDividingCubes.Probability);

        if (cube.TryGetComponent<Collider>(out Collider collider))
        {
            if (collider.attachedRigidbody != null)
            {
                _explosionGenerator.AddExplosibleCube(collider.attachedRigidbody);
            }
        }
    }
}