using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulcano : MonoBehaviour
{
   public Grenade grenadePrefab;
   public float force = 500;
   public float delayMin = 1;
   public float delayMax = 3;

   private void Start()
   {
       Invoke("SpawnGrenade", Random.Range(delayMin, delayMax));
   }

   private void SpawnGrenade()
   {
	   var grenade = Instantiate(grenadePrefab);
       grenade.transform.position = transform.position;
       grenade.GetComponent<Rigidbody>().AddForce(transform.forward * force);
       Invoke("SpawnGrenade", Random.Range(delayMin, delayMax));
   }
}
