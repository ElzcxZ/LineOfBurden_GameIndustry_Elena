using UnityEngine;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{
    public GameObject itemToSpawn;
    public Transform[] lanes;
    private int winDistance = Cart.winDistance;
    public int distance = 5;
    public int obstacleCutoff = 1; //amount of obstacles to stop generating before the winDistance
    

    private void Start()
    {
        int iterations = winDistance/distance - obstacleCutoff; // calculates how many obstacles needed to finish generating at the end-line
        
        for (int i = 0; i < iterations; i++)
        {
            int idx = Random.Range(0, lanes.Length);
            Transform lane = lanes[idx];
            
            Instantiate(itemToSpawn, lane.position, lane.rotation);
            transform.position += Vector3.forward  * distance;
        }
    }
}
