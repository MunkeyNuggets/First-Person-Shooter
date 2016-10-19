using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public float health = 100.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void takeDamage(float dmg){

		health -= dmg;

		if (health <= 0)
			Destroy (this.gameObject);
	}
}
