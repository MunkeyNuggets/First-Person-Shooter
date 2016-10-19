using UnityEngine;
using System.Collections;

public class RocketLauncherProjectile : MonoBehaviour {

	private Transform myTransform;
	
	public float projectileSpeed = 15.0f;
	public float projectileDamage = 5.0f;
	public float despawnTime = 5.0f;

	private float currentTime;

	//Projectile Effects
	public GameObject rocketExplosionEffect;
	public GameObject rocketSmoke;

	public float rocketSmokeTime = 0.1f;
	private float rocketSmokeTimer;

	//Audio
	public GameObject explosionSound;
	public GameObject rocketFlying;

	//Damage Game Object
	public GameObject explosionDamage;
	
	// Use this for initialization
	void Start () {
		myTransform = this.transform;

		GameObject thisSound = Instantiate(rocketFlying, myTransform.position, myTransform.rotation) as GameObject;
		thisSound.transform.parent = transform;

        Destroy(this.gameObject, despawnTime);
    }
	
	// Update is called once per frame
	void Update () {

        projectileMovement();

        visualEffect();
	}

    //Projectile Movement
    void projectileMovement(){

		currentTime += Time.deltaTime;

		projectileSpeed = 20 * Mathf.Log10 (currentTime + 0.5f) + 20;
       
        //Projectile Forward Movement
        myTransform.position += projectileSpeed * Time.deltaTime * myTransform.forward;
    }

    //Projectile Visual Effect
    void visualEffect() {
        //Release Smoke Effect
        if (rocketSmokeTimer <= Time.time) {
            Instantiate(rocketSmoke, myTransform.position, myTransform.rotation);
            rocketSmokeTimer = Time.time + rocketSmokeTime;
        }
    }
	
	//When colliding with another object...
	void OnCollisionEnter(Collision collidingObject){
		Instantiate (rocketExplosionEffect, myTransform.position, myTransform.rotation);
		Instantiate (explosionSound, myTransform.position, myTransform.rotation);
		Instantiate (explosionDamage, myTransform.position, myTransform.rotation);
		Destroy (this.gameObject);
	}
}
