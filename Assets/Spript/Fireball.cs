using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage = 10;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        FixedUpdate();
        Invoke("DestroyFireball", lifetime);
    }
    private void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyFireball();
    }
    private void DestroyFireball()
    {
        Destroy(gameObject);
    }

    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }
}
