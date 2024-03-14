using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
