using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    public void ChangeSize()
    {
        float initialScale = transform.localScale.x;

        DecreaseSizeValue(ref initialScale);

        transform.localScale = Vector3.one * initialScale;
    }

    private void DecreaseSizeValue(ref float scaleValue)
    {
        float halving = 0.5f;

        scaleValue *= halving;
    }
}