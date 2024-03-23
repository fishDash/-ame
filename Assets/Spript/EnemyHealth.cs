using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator animator;

    public PlayerProgress playerProgress;

    public Explosion explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DealDamage(float damage)
    {
        playerProgress.AddExperience(damage);

        value -= damage;
        if (value <= 0)
        {
            EnemyDeath();
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }

    private void EnemyDeath()
    {
        animator.SetTrigger("death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;

        if (explosionPrefab == null) return;
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
    }
}