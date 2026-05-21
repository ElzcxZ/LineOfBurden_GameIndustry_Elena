using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float weightIncrease = 0.5f;
    private Cart cart;

    void Start()
    {
        cart = GameObject.Find("Cart").GetComponent<Cart>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (cart != null)
            {
                cart.AddWeight(weightIncrease);
                Destroy(gameObject);
            }
        }
    }
}

