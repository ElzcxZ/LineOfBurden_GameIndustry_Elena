using UnityEngine;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{
    public GameObject itemToSpawn;
    public Transform[] lanes;
    float winDistance = Cart.winDistance;
    public float distance = 5f;
    public int iterations = 100;
    

    private void Start()
    {
        for (int i = 0; i < iterations; i++)
        {
            int idx = Random.Range(0, lanes.Length);
            Transform lane = lanes[idx];
            
            Instantiate(itemToSpawn, lane.position, lane.rotation);
            transform.position += Vector3.forward  * distance;
        }
    }
}
