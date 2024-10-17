using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isKey;
    private Collect key;
    public bool onDoor = false;

    public Animator doorAnim;
    public bool isOpen;
    public GameObject playerKey;
    private SoundManager soundManager;

//-------------------------------------------------------------------------//

    private void Awake()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
        isKey = playerKey.GetComponent<Collect>().isKey;
    }

    private void Start()
    {
        isOpen = false;
    }

    private void Update()
    {
        isKey = playerKey.GetComponent<Collect>().isKey;
        if (!isOpen)
        {
            OpenDoor();
        }
    }

//---------------------------------------------------------------------------//

    private void OpenDoor()
    {
        if (Input.GetKeyDown("e") && isKey && onDoor)
        {
            doorAnim.SetBool ("isOpening", true);
            isOpen = true;
            soundManager.AudioSelection (2, 0.5f);
        }
        else
        {
            isOpen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onDoor = false;
        }
    }

}
