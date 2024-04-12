using System.Collections;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 1;

    private Coroutine _selfDestruct;

    private void Start()
    {
        _selfDestruct = StartCoroutine(SelfDestruct());
    }

    private IEnumerator SelfDestruct()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_lifeTime);

        int numberCycles = 1;
        
        for (int i = 0; i < numberCycles; i--) 
        {
            yield return waitForSeconds;
           
            _selfDestruct = null;
            Destroy(gameObject);
        }
    }
}