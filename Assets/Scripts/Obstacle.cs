using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float weightIncrease = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cart player = other.GetComponentInParent<Cart>();
            if (player != null)
            {
                player.AddWeight(weightIncrease);
                Destroy(gameObject);
            }
        }
    }
}
