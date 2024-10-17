using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrompTXT : MonoBehaviour
{  

    public GameObject canv;


    private void Start()
    {
        canv.SetActive(false);
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canv.SetActive(true);
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canv.SetActive(false);
        }
    }
}
