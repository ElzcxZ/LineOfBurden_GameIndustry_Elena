using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{ 
    public float movementSpeed = 5.5f;
    
    public int currentLane = 0; // 1 = left, 2 = middle, 3 = right
    public int maxLane = 2; // actual number of lanes = maxLane + 1
    public float laneDistance = 3f;
    public float laneSwitchSpeed = 1.5f;

    public bool isMoving = false;
    public float weight = 1f; // 1 = normal weight, 2 = double weight, (minimum 1)
    private float targetX;
    private float newX;

    void Start()
    {
        Debug.Log(currentLane.ToString());
    }
    
    // Update is called once per frame
    void Update()
    {
        // player constant movement 
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            isMoving = true;
            Debug.Log(currentLane.ToString());
        }
        if (isMoving)
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime); 
        }
        
        // if "A" is pressed, switch to the next left lane
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            currentLane = Mathf.Clamp(currentLane - 1, 1, maxLane); // "Mathf.Clamp" locks the first value between the 2nd value and the 3rd value
            Debug.Log(currentLane.ToString());
        }
        // if "D" is pressed, switch to the next right lane
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            currentLane = Mathf.Clamp(currentLane + 1, 1, maxLane);
            Debug.Log(currentLane.ToString());
        }
        
        // calculate target X location
        targetX = currentLane;
        // smooth movement to lane
        newX = Mathf.Lerp(transform.position.x, targetX, laneSwitchSpeed * Time.deltaTime / weight); // "Mathf.Lerp" linearly transitions between 1st value and 2nd value, with the speed of the 3rd value
        
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}


