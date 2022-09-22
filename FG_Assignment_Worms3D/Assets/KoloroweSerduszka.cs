using UnityEngine;
using UnityEngine.UI;

public class KoloroweSerduszka : MonoBehaviour
{
    private Image heartImage;

    private void Awake()
    {
        heartImage = GetComponent<Image>();
    }

    public void ChangeColor(Color color)
    {
        heartImage.color = color;
    }
}
