using UnityEngine;
using UnityEngine.InputSystem;

public class Cart : MonoBehaviour
{
    public float movementSpeed = 5.5f;
    
    private bool isMoving = false;
    private bool isGameOver = false;
    public GameObject gameOverUI;

    public static int winDistance = 100; //
    private float startZ;
    public static bool hasWon = false;
    
    public float weight = 1f; // 1 = normal weight, 2 = double weight, (minimum 1)
    private float minWeight = 1f;
    public float maxWeight = 3f;
    public float weightIncreaseSpeed = 0.05f;

    public float cooldown = 3f;
    public float lastResetTime = 0f;

    public void AddWeight(float amount)
    {
        weight += amount;
    }

    void GameOver()
    {
        isGameOver = true;
        movementSpeed = 0f;
        isMoving = false;
        gameOverUI.SetActive(true);
    }

    void Win()
    {
        hasWon = true;
        
        movementSpeed = 0f;
        isMoving = false;
    }

    void Start()
    {
        startZ = transform.position.z; //captures starting position
    }
    
    void Update()
    {
        float distanceTraveled = transform.position.z - startZ; //find the distance traveled

        if (!hasWon && !isGameOver && distanceTraveled >= winDistance) //if haven't won yet, haven't lost, and reached the finish line, you win
        {
            Win();
        }
        
        if (weight >= maxWeight && !isGameOver && !hasWon)
        {
            GameOver();
        }
        
        // player constant movement 
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            isMoving = true;
        }
        
        if (isMoving)
        {
            weight += weightIncreaseSpeed * Time.deltaTime; // increase weight over time
            weight = Mathf.Clamp(weight, 1f, maxWeight);
            transform.Translate(Vector3.forward * (movementSpeed / weight) * Time.deltaTime); 
        }

        // if "F" is pressed, and if current time is greater than the last time cooldown was reset + cooldown, resets weight
        if (Keyboard.current.fKey.wasPressedThisFrame && Time.time >= lastResetTime + cooldown)
        {
            weight = minWeight;
            lastResetTime = Time.time; // sets variable to current time
        }
    }
        
}