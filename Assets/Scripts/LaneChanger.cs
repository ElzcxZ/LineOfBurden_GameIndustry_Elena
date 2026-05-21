using UnityEngine;
using UnityEngine.InputSystem;

public class LaneChanger : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public Transform[] lanes;
    
    public int currentLane = 1; // 0 = left, 1 = middle, 2 = right
    public float laneSwitchSpeed = 1.5f;
    

    private void Update()
    {
        bool hasWon = Cart.hasWon;
            
        // if "A" is pressed, switch to the next left lane
        if (Keyboard.current.aKey.wasPressedThisFrame && !hasWon)
        {
            currentLane =
                Mathf.Max(currentLane - 1, 0); // "Mathf.Clamp" locks the first value between the 2nd value and the 3rd value
        }

        // if "D" is pressed, switch to the next right lane
        if (Keyboard.current.dKey.wasPressedThisFrame && !hasWon)
        {
            currentLane = Mathf.Min(currentLane + 1, lanes.Length - 1);
        }
    }
    
    void FixedUpdate()
    {
        Vector3 nextPosition = Vector3.MoveTowards(transform.position, lanes[currentLane].position, laneSwitchSpeed * Time.fixedDeltaTime);
        nextPosition.y = transform.position.y;
        nextPosition.z = lanes[currentLane].position.z;

        myRigidbody.MovePosition(nextPosition);
    }
}