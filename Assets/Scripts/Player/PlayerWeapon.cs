using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
     public int damage = 3;
    public bool enemyHit = false;
    public bool canAttack;
    public GameObject player;
    
    private void Update()
    {
        canAttack = player.GetComponent<PlayerController>().canAttack;
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Enemy") && canAttack)
        {
            if (!enemyHit)
            {
                Debug.Log(other.name);
                other.gameObject.GetComponent<EnemyController>().enemyLife -= damage;
                //coge el componente EnemyController (script) del objeto con el que colisiona,
                //y dentro de ese componente (el script) el valor de EnemyLife.
                enemyHit = true;
                Invoke("ResetHit", 0.35f);
            }
        }
    }

    private void ResetHit()
    {
        enemyHit = false;
    }
}
