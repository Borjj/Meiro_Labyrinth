using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public int damage = 5;
    public bool playerHit = false;
    public bool isSwinging;
    public GameObject enemy;
    

    private void Update()
    {
        isSwinging = enemy.GetComponent<EnemyController>().swinging;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player") && isSwinging)
        {
            if (!playerHit)
            {
                other.gameObject.GetComponent<PlayerController>().playerLife -= damage;
                //coge el componente PlayerController (script) del objeto con el que colisiona,
                //y dentro de ese componente (el script) el valor de Playerlife.
                playerHit = true;
                Invoke("ResetHit", 1.0f);
            }
        }
    }

    private void ResetHit()
    {
        playerHit = false;
    }
}
