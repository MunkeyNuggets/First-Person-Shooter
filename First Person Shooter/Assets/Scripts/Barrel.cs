using UnityEngine;
using System.Collections;

public class Barrel : Entity {

	private Transform myTransform;

    //Effects
	public GameObject barrelExplosion;
	public GameObject explosionDamage;
	public GameObject explosionSound;

	// Use this for initialization
	void Start () {
		myTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public override void takeDamage(float dmg){
		health -= dmg;

        if (health <= 0){
            Instantiate(barrelExplosion, myTransform.position, myTransform.rotation);
            Instantiate(explosionSound, myTransform.position, myTransform.rotation);
            Instantiate(explosionDamage, myTransform.position, myTransform.rotation);
            Destroy(this.gameObject);
        }
    }
}
