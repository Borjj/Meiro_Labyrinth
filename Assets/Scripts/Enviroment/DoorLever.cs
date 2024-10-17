using UnityEngine;

public class DoorLever : MonoBehaviour
{
   [Header ("Door")]
    public bool onDoor = false;
    private SoundManager soundManager;
    public float openHeight;
    public float openSpeed;
    public bool isOpen = false;
    private Vector3 closedPosition;
    private Vector3 openPosition;

    [Header ("Lever Door")]
    public GameObject lever;
    public bool leverCondition;

//------------------------------------------------------------------------//    

    private void Awake()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
    }


    private void Start()
    {
        closedPosition = transform.position;
        openPosition = new Vector3 (closedPosition.x, closedPosition.y + openHeight, closedPosition.z);
    }

    private void Update()
    {
        CheckLever();
        OpenDoorLever();
        
        if (isOpen)
        {
            OpenDoor();
        }
    }

//--------------------------------------------------------------------//

    private void OpenDoorLever()
    {
        if (Input.GetKeyDown("e") && leverCondition && onDoor)
        {
            soundManager.AudioSelection (2, 0.5f);
            isOpen = true;
        }
    }

    private void CheckLever()
    {
        leverCondition = lever.GetComponent<Lever>().isActive;
    }

    private void OpenDoor()
    {
        transform.position = Vector3.MoveTowards(transform.position, openPosition, openSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onDoor = false;
        }
    } 
}
