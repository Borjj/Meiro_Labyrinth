using UnityEngine;

public class DoorCoins : MonoBehaviour
{
    [Header ("Door")]
    public bool onDoor = false;
    private SoundManager soundManager;
    public float openHeight;
    public float openSpeed;
    public bool isOpen = false;
    private Vector3 closedPosition;
    private Vector3 openPosition;


    [Header ("Coins Door")]
    public GameObject player;
    public bool hasEnoughCoins = false;
    public int coinsRequired;
    public int coinsPlayer;

//-------------------------------------------------------------------------//

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
        CheckCoins();
        OpenDoorCoins();

        if (isOpen)
        {
            OpenDoor();
        }
    }


//-------------------------------------------------------------------------//

    private void OpenDoorCoins()
    {
        if (Input.GetKeyDown("e") && onDoor && hasEnoughCoins)
        {
            isOpen = true;
            soundManager.AudioSelection (2, 0.5f);
        }
    }

    private void CheckCoins()
    {
        coinsPlayer = player.GetComponent<Collect>().count;
        hasEnoughCoins = coinsPlayer >= coinsRequired;
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
