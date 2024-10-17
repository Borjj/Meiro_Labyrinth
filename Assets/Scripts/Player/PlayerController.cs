using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header ("Components")]
    public Rigidbody rb;
    public Animator playerAnim;
    private SoundManager soundManager;
    public Transform player;

    [Header ("Attributes")]
    public int jumpImpulse = 6; //fuerza del salto
    public float fallMultiplier; //velocidad de caida
    public float lowJumpMultiplier;
    public int playerLifeMAX; //vida MAX del jugador
    public int playerLife; //Vida actual del jugador
    public bool canAttack; //esta atacando?

    [Header ("Variables")]
    public float speed;
    public float maxSpeed = 8f;
    public Vector3 movementX;
    public Vector3 movementY;
    public Vector3 movementZ;
    public Vector3 movement;
    public Vector3 movementXZ;
    public bool grounded = false;
    public float magnitude; //magnitud del vector de movimiento
    public float mouseX;
    public float mouseSensitibity = 3.0f;

    [Header ("Spawns")]
    public Transform spawn001;

//-----------------------------------------------------------//
  
    private void Awake()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
    }

    private void Start()
    {
        playerLife = playerLifeMAX;
        speed = maxSpeed;
        canAttack = true;
    }

    // Update is called once per frame
    private void Update() 
    {
        Movement();
        Jump();
        Attacking();
        Respawn();
        

        magnitude = rb.velocity.magnitude;
    }

//--------------------------------------------------------------------//
    private void Movement()
    {
        movementX = transform.right * Input.GetAxis("Horizontal") * speed; //coge la info del eje Horizontal para el movimiento
        movementY = new Vector3 (0f, rb.velocity.y, 0f); //la velocidad en Y
        movementZ = transform.forward * Input.GetAxis("Vertical") * speed; //coge la info del eje Vertical para el movimento
        movementXZ = movementX + movementZ; //Vector 3 con la info de los ejes vertical y horizontal
        movement = Vector3.ClampMagnitude(movementXZ, speed) + movementY; //normaliza la magnitud del vector XZ y le suma la info del movimiento en Y

        mouseX += Input.GetAxis("Mouse X") * mouseSensitibity;
        player.rotation = Quaternion.Euler (0f, mouseX, 0f); //el player rota en el eje Y al unisono que la camara
        

        rb.velocity = movement; //Vector final del movimiento, con la info del vector XZ nromalizado para evitar movimiento diagonal más rapido


        if (rb.velocity.z != 0 || rb.velocity.x != 0)
        {
            playerAnim.SetBool ("isWalking", true);
        }

        else
        {
            playerAnim.SetBool  ("isWalking", false);
        }
        
    }


    private void Jump()
    {
        if (Input.GetKeyDown("space") && grounded)
        {
            rb.velocity = Vector3.zero; //siempre que salte la velocidad en "y" sera 0.
            rb.AddForce(transform.up * jumpImpulse, ForceMode.Impulse);
            playerAnim.SetBool ("isJumping", true);
        }
        else
        {
            playerAnim.SetBool ("isJumping", false);
        }


        //hace que el Player salte mas o menos segun cuanto presiona la tecla de salto.
        if (rb.velocity.y < 0) //acelera la velocidad de caida una vez en el aire
        {
             rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }


    }


    private void Attacking()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if(canAttack)
            {
                canAttack = false;
                playerAnim.SetBool ("isAttacking", true);
                Invoke ("AttackReset", 0.35f);
                Invoke ("AttackSound", 0.40f);
            }
        }

        if(Input.GetButtonUp("Fire2"))
        {
            canAttack = true;
        }
    }

    private void AttackReset()
    {
        playerAnim.SetBool ("isAttacking", false);
        canAttack = true;
    }

    public void AttackSound()
    {
        soundManager.AudioSelection (0, 0.6f); //reproducir el clip "0" del script SoundManager
    }


    public void Respawn()
    {
        if(playerLife <= 0)
        {   
            speed = 0;
            grounded = false;
            playerAnim.SetBool("isDead", true);
            Invoke ("SpawnPoint", 3.0f);
        }
        else
        { 
            speed = maxSpeed;
            playerAnim.SetBool("isDead", false);
        }
    }

    public void SpawnPoint()
    {
        //Deshabilitar el Collider temporalmente
        Collider col = GetComponent<Collider>();
        col.enabled = false;

        //Reset velocidad
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        //Mover el player al spawnPoint
        transform.position = spawn001.position;

        //Rehabilitar el Collider
        col.enabled = true;

        //Reset de la vida y la animacion
        playerLife = playerLifeMAX;
        playerAnim.SetBool("isDead", false); //regresa a la animacion idle

        //asegurar que el jugador no atraviese el suelo por error
        grounded = true;
    }

    private void OnCollisionStay (Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Ground")
        {
            grounded = true;
            playerAnim.SetBool ("isJumping", false);
        }
    }

    private void OnCollisionExit (Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}