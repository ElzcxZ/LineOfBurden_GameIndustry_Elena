using UnityEngine;
using UnityEngine.UI;

public class BlinkImage : MonoBehaviour
{
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        Color color = image.color;
        
        color.a = Mathf.Abs(Mathf.Sin(Time.time * 1.2f));
        
        image.color = color;
    }
}
