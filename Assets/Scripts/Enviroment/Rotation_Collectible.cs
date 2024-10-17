using UnityEngine;
using System.Collections;

public class Rotation_Collectible : MonoBehaviour
{

    private SoundManager soundManager;

    [Header ("Key")]
    public float rotSpeedKEY;
    public bool key;

    [Header("Coin")]
    public float rotSpeedCOIN;
    public bool coin;

//-------------------------------------------------------------------------//

    private void Awake()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
    }

    private void Update()
    {
        RotationMov();
    }


//-------------------------------------------------------------------------//

    private void RotationMov()
    {
        if (key)
        {
            transform.Rotate (new Vector3 (0f, rotSpeedKEY, 0f));
        }

        if (coin)
        {
            transform.Rotate (new Vector3 (0f, rotSpeedCOIN, 0f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (key)
            {
                soundManager.AudioSelection (4, 0.7f);
            }
            if (coin)
            {
                soundManager.AudioSelection (3, 0.5f);
            }
        }
    }
}
