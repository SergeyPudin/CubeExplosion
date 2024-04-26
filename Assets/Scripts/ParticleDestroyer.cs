using System.Collections;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    [SerializeField] private float _effectLifetime = 1;

    private Coroutine _selfDestruct;

    private void Start()
    {
        _selfDestruct = StartCoroutine(SelfDestruct());
    }

    private IEnumerator SelfDestruct()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_effectLifetime);

        yield return waitForSeconds;

        _selfDestruct = null;
        Destroy(gameObject);
    }
}