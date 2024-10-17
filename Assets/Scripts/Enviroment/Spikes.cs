using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int spikeDmg = 999;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().playerLife -= spikeDmg;    
        }
    }
}
