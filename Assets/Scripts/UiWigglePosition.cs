using UnityEngine;
using UnityEngine.EventSystems;

public class UiWigglePosition : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler
{
    public float amount = 5f;
    public float speed = 1f;

    private RectTransform rect;
    private Vector2 startPos;
    

    private bool isHovered = false;

    private float offsetX;
    private float offsetY;
    
    void Start()
    {
        rect = GetComponent<RectTransform>();
        
        startPos = rect.anchoredPosition;
        
        // unique movement per button
        offsetX = Random.Range(0f, 100f);
        offsetY = Random.Range(0f, 100f);
    }
    
    void Update()
    {
        // only wiggle when hovered
        if (isHovered)
        {
            float xNoise = Mathf.PerlinNoise((Time.time * speed) + offsetX, 0f);
            float yNoise = Mathf.PerlinNoise(0f, (Time.time * speed) + offsetY);

            // convert PerlinNoise's 0 - 1 range into -1 - 1
            float x = (xNoise - 0.5f) * 2f * amount;
            float y = (yNoise - 0.5f) * 2f * amount;
        
            rect.anchoredPosition = startPos + new Vector2(x, y);
        }
        else
        {
            rect.anchoredPosition = startPos;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }
    
    // hover exit
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }
}
