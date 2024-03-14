using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public Fireball fireballPrefab;
    public Transform fireballSourceTransform;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
       if (Input.GetMouseButtonDown(0))
       {
            Instantiate(fireballPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
       }
    }
}
