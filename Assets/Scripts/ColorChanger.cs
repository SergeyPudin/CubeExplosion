using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color[] _colors;

    public void ChangeColor()
    {      
        Material material = GetComponent<Renderer>().material;
        Color initialColor = material.color;

        RandomizeColor(ref initialColor);

        material.color = initialColor;
    }
    
    private void RandomizeColor(ref Color color)
    {
        int random = Random.Range(0, _colors.Length);

        color = _colors[random];
    }
}