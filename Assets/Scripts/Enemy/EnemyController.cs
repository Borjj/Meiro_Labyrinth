using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target; //el target que sigue
    public NavMeshAgent enemyNavMesh;
    public Animator enemyAnim;
    private SoundManager soundManager;

    [Header ("Distances")]
    public float distance;
    public float distanceToFollow;
    public float distanceToAttack;

    [Header ("Atributes")]
    public int enemyLifeMAX;
    public int enemyLife;
    public float cooldown = 1.0f;
    private float lastAttack = -9999f;
    public bool swinging = false;
    public int score;
    public bool alive;
    public bool dead;

//------------------------------------------------//

    private void Awake()
    {
        soundManager = FindAnyObjectByType<SoundManager>();
    }

    private void Start()
    {
        alive= true;
        dead = false;
        enemyLife = enemyLifeMAX;
    }

    private void Update()
    {
        distance = Vector3.Distance (transform.position, target.position); //distancia entre enemigo y player

        EnemyMovement();
        EnemyAttack();
        EnemyLife();
    }

//---------------------------------------------//

    private void EnemyMovement()
    {
        if ((distance < distanceToFollow) && (distance > distanceToAttack) && alive)
        {
            enemyNavMesh.isStopped = false;
            enemyAnim.SetBool("isAttacking", false);

            enemyAnim.SetBool("isWalking", true);
            enemyNavMesh.destination = target.position; //persigue la posicion del target
        }

        else
        {
            enemyAnim.SetBool("isWalking", false);
            enemyAnim.SetBool("isAttacking", false);
            enemyNavMesh.isStopped = true; //deja de perseguir
        }
    }

    private void EnemyAttack()
    {
        if (distance <= distanceToAttack && alive)
        {
            enemyNavMesh.stoppingDistance = distanceToAttack - 0.2f;
        
            if (Time.time > lastAttack + cooldown)
            {
                swinging = true;
                enemyAnim.SetBool("isAttacking", true);
                soundManager.AudioSelection (1, 0.6f); //reproducir el clip "1" del script SoundManager
                
                lastAttack = Time.time;
            }
            
        }
        else
        {
            enemyAnim.SetBool("isAttacking", false);
            swinging = false;
        }
    }

    private void EnemyLife()
    {
        if (enemyLife <= 0 && alive)
        {  
            enemyNavMesh.destination = transform.position; //deja de perseguir
            enemyAnim.SetBool("Hit", true);
            alive = false;

            ScoreManager.instance.AddScore(1); //agrega 1 al valor de score del script ScoreManager
        }
    }
}