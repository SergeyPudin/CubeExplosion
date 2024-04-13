using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color[] _colors;

    private Material _material;

    private void Awake()
    {      
        _material = GetComponent<Renderer>().material;
    }
    
    public void ChangeColor()
    {
        int random = Random.Range(0, _colors.Length);

        _material.color = _colors[random];
    }
}