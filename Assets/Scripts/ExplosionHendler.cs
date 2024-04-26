using UnityEngine;

[RequireComponent(typeof(ExplosionGenerator), typeof(ProbabilityCalculator), typeof(CubeSpawner))]
public class ExplosionHendler : MonoBehaviour
{
    private CubeSpawner _cubeSpawner;
    private ExplosionGenerator _explosionGenerator;
    private ProbabilityCalculator _probabilityDividingCubes;

    private float _explosionForceCoefficient;

    private void Start()
    {
        _cubeSpawner = GetComponent<CubeSpawner>();
        _explosionGenerator = GetComponent<ExplosionGenerator>();

        _probabilityDividingCubes = GetComponent<ProbabilityCalculator>();
    }

    public void Explode()
    {
        float defaultCoefficient = 1.0f;
        float coefficientChange = 2.0f;

        int minQuantity = 2;
        int maxQuantity = 6;
        int randomValue = Random.Range(minQuantity, maxQuantity);

        _probabilityDividingCubes.IsDevide();

        if (_probabilityDividingCubes.IsDeviding)
        {
            _explosionForceCoefficient = _explosionForceCoefficient == 0 ? defaultCoefficient : _explosionForceCoefficient *= coefficientChange;

            for (int i = 0; i < randomValue; i++)
            {
                CreateCubes(_explosionForceCoefficient);
                _explosionGenerator.ExploseNewBornCubes();
            }
        }
        else
        {
            _explosionGenerator.ExplodeAllCubes(_explosionForceCoefficient);
        }

        Destroy(gameObject);
    }

    public void UpdateProbability(ProbabilityCalculator probability)
    {
        _probabilityDividingCubes = probability;
    }

    public void SetExplosionForce(float coefficient)
    {
        _explosionForceCoefficient = coefficient;
    }

    private void CreateCubes(float exploderCoefficient)
    {
        Cube cube = _cubeSpawner.SpawnCube();
        ExplosionHendler hendler = cube.GetComponent<ExplosionHendler>();

        cube.GetColor();
        cube.GetSize();

        hendler.SetExplosionForce(exploderCoefficient);

        hendler.UpdateProbability(_probabilityDividingCubes);
        cube.GetComponent<ProbabilityCalculator>().SetProbability(_probabilityDividingCubes.Probability);

        if (cube.TryGetComponent<Collider>(out Collider collider))
        {
            if (collider.attachedRigidbody != null)
            {
                _explosionGenerator.AddNewBorneCube(collider.attachedRigidbody);
            }
        }
    }
}