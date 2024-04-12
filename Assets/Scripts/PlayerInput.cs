using UnityEngine;

[RequireComponent(typeof(Exploder))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Collider _wall;
    [SerializeField] private  LayerMask _raycastLayer;

    private Exploder _exploder;

    private void Start()
    {
        _exploder = GetComponent<Exploder>();
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
                    _exploder.Explode();
                }
            }
        }
    }
}