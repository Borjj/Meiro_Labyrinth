using UnityEngine;

public class Lever : MonoBehaviour
{
    public Animator anim;
    public bool isActive;
    public bool canActivate;
    public AudioSource leverAudio;

//----------------------------------------------------------------//

    private void Start()
    {
        isActive = false;

        anim = GetComponent<Animator>();
        leverAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!isActive)
        {
            ActivateLever();
        }
    }

//-------------------------------------------------------------------------//

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canActivate = false;
        }
    }


    private void ActivateLever()
    {
        if (Input.GetKeyDown ("e") && canActivate)
            {
                anim.SetBool("Lower_Lever", true);
                leverAudio.Play();
                isActive = true;
            }
    }
}
