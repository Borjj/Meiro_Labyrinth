using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    public float rotSpeed;
    

    // Update is called once per frame
    void Update()
    {
        RotationMov();
    }

    private void RotationMov()
    {
        transform.Rotate (new Vector3 (0f, rotSpeed, 0f));
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.SetParent(transform);
        }
    }
 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.SetParent(null);
        }
    }

}
