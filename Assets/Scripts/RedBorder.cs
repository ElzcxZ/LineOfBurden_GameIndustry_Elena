using UnityEngine;
using UnityEngine.UI;

public class RedBorder : MonoBehaviour
{
    public Image redBorder;
    public Cart cart;
    
    public float fadeSpeed = 1f;
    
    void Update()
    {
        float normalized = (cart.weight - 1f) / (cart.maxWeight);
        float t = Mathf.Clamp01(normalized);

        Color c = redBorder.color;
        c.a = Mathf.Lerp(c.a, t, Time.deltaTime * fadeSpeed);
        redBorder.color = c;
    }
}
