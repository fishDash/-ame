using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulcano : MonoBehaviour
{
   public Grenade grenadePrefab;
   public float force = 500;

   private void SpawnGrenade()
   {
	   var grenade = Instantiate(grenadePrefab);
       grenade.transform.position = transform.position;
       grenade.GetComponent<Rigidbody>().AddForce(transform.forward * force);
   }
}
