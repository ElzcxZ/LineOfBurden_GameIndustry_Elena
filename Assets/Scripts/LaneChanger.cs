using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaneChanger : MonoBehaviour
{
    public Transform[] lanes;
    
    public int currentLane = 1; // 0 = left, 1 = middle, 2 = right
    public float laneSwitchSpeed = 1.5f;

    private void Update()
    {
        // if "A" is pressed, switch to the next left lane
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            currentLane = Mathf.Max(currentLane - 1, 0); // "Mathf.Clamp" locks the first value between the 2nd value and the 3rd value
        }
        // if "D" is pressed, switch to the next right lane
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            currentLane = Mathf.Min(currentLane + 1, lanes.Length - 1);
        }
        
        Vector3 nextPosition = Vector3.MoveTowards(transform.localPosition, lanes[currentLane].localPosition, laneSwitchSpeed * Time.deltaTime);
        transform.localPosition = nextPosition;
    }
}