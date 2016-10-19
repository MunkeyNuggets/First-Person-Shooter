using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosionAOE : MonoBehaviour {

    public float damage = 100.0f;

    public float lifeTime = 0.05f;
    private float lifeTimeDuration;

    public List<GameObject> damageTargets = new List<GameObject>();

    public float radius = 15.0f;

    GameManager gameManager;

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        //Destroy (this.gameObject, lifeTime);
        lifeTimeDuration = Time.time + lifeTime;

        transform.GetComponent<SphereCollider>().radius = radius;
    }


    void Update() {

        //Explosion finishes, damage targets and remove AOE field
        if (Time.time > lifeTimeDuration) {
            foreach (GameObject target in damageTargets) {
                if (target != null) {
                    //Calculate damage based on proximity to centre of explosion
                    float thisDamage = ((radius - Vector3.Distance(target.transform.position, transform.position)) / radius) * damage;
                    print(thisDamage);
                    target.GetComponent<Entity>().takeDamage(thisDamage);
                    //target.SendMessage("takeDamage", damage);   //<< This is not good code. Let's fix this!
                }
            }
            Destroy(this.gameObject);
        }
    }


    void OnTriggerEnter(Collider otherObject) {

        if (otherObject.gameObject.tag == "Enemy") {
            damageTargets.Add(otherObject.gameObject);
        }

		//Rocket Jumping
		if (otherObject.gameObject.tag == "Player") {
			Vector3 jumpVector = (otherObject.transform.position - transform.position).normalized;
			jumpVector *= 25;
			otherObject.GetComponent<CharacterMotor> ().SetVelocity (jumpVector);
		}
    }
}
