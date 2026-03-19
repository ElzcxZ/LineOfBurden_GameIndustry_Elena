using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{ 
    public float movementSpeed = 5.5f;
    
    public int currentLane = 1; // 0 = left, 1 = middle, 2 = right
    public int maxLane = 2; // actual number of lanes = maxLane + 1
    public float laneSwitchSpeed = 1.5f;

    private bool isMoving = false;
    private float newX;
    
    public float weight = 1f; // 1 = normal weight, 2 = double weight, (minimum 1)
    private float minWeight = 1f;
    public float maxWeight = 3f;
    public float weightIncreaseSpeed = 0.05f;
    
    public float cooldown = 3f;
    public float lastResetTime = 0f;
    
    
    // Update is called once per frame
    void Update()
    {
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
        
        // if "A" is pressed, switch to the next left lane
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            currentLane = Mathf.Clamp(currentLane - 1, 0, maxLane); // "Mathf.Clamp" locks the first value between the 2nd value and the 3rd value
        }
        // if "D" is pressed, switch to the next right lane
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            currentLane = Mathf.Clamp(currentLane + 1, 0, maxLane);
        }

        // if "F" is pressed, and if current time is greater than the last time cooldown was reset + cooldown, resets weight
        if (Keyboard.current.fKey.wasPressedThisFrame && Time.time >= lastResetTime + cooldown)
        {
            weight = minWeight;
            lastResetTime = Time.time; // sets variable to current time
        }
        
        // smooth movement to lane
        newX = Mathf.Lerp(transform.position.x, currentLane, laneSwitchSpeed * Time.deltaTime / weight); // "Mathf.Lerp" linearly transitions between 1st value and 2nd value, with the speed of the 3rd value
        
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}