using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterActions : MonoBehaviour
{
   public int health = 100;
   public const int MAX_HEALTH = 100;
   
   public bool canShoot = true;

   [Range(0,5)]
   public float bulletdelay = 1f;

   public GameObject bullet;

   void Start() {

   }

   public void TakeDamage(int damage) {
      health = health - damage;
      if(health <= 0) {
         
         Destroy(gameObject); // TODO: Sometimes respawns player when opponent dies
      }
   }
 
   public void Shoot()
   {
      if(canShoot) {
         // When you press the Key
         canShoot = false;

         GameObject _bullet = Instantiate(bullet, transform.position + transform.forward, transform.rotation);
         //Physics.IgnoreCollision(_bullet.GetComponent<Collider>(), GetComponent<Collider>());

         _bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _bullet.GetComponent<ProjectileStats>().speed );

         StartCoroutine(ShootDelay());
         IEnumerator ShootDelay()
         {
               
               yield return new WaitForSeconds(bulletdelay);
               canShoot = true;
               //Destroy(_bullet);
         }

         // Delay in shooting setup now shoot bullet
         
        
      }
   }

   void OnTriggerEnter(Collider other) {
      if(other.CompareTag("Projectile")) {
         Debug.Log("Hit: " + gameObject.ToString());
         TakeDamage(other.gameObject.GetComponent<ProjectileStats>().damage);
         Destroy(other.gameObject);
      }
   }
}
