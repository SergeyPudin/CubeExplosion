using UnityEngine;

[RequireComponent(typeof(ColorChanger), typeof(SizeChanger))]
public class Cube : MonoBehaviour 
{
    private ColorChanger _colorChanger;
    private SizeChanger _sizeChanger;

    private void Awake()
    {
        _colorChanger = GetComponent<ColorChanger>();
        _sizeChanger = GetComponent<SizeChanger>();
    }

    public void GetSize()
    {
        _sizeChanger.ChangeSize();
    }

    public void GetColor()
    {
        _colorChanger.ChangeColor();
    }
}