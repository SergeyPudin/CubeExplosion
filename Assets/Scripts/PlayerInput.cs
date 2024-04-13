using UnityEngine;

[RequireComponent(typeof(ExplosionHendler))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private  LayerMask _raycastLayer;

    private ExplosionHendler _explosionHandler;

    private void Start()
    {
        _explosionHandler = GetComponent<ExplosionHendler>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _raycastLayer))
            {
                if (hit.collider.gameObject == gameObject)
                {                   
                    _explosionHandler.Explode();
                }
            }
        }
    }
}