using UnityEngine;
using System.Collections;

public class Enemy : Entity {

	private NavMeshAgent agent;

	public GameObject target;

	GameManager gameManager;

	public int points = 10;

	public float damage = 10.0f;
	private float damageInterval = 1.0f;
	private float damageTimer;

	//State Machine Enumerator
	public enum EnemyState{
		Idle,
		Attack
	}

	public EnemyState enemyState;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();

		agent = GetComponent<NavMeshAgent> ();

		target = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		EnemyLogic ();

		EnemyBehaviour ();
	}

	//Logical Transitions
	void EnemyLogic(){
		//Raycast towards the player
		RaycastHit hit;

		if (Physics.Raycast (transform.position, (target.transform.position - transform.position).normalized, out hit)) {
			//Hit player?
			if(hit.transform.tag == "Player"){
				//STATE TRANSITION: ATTACK
				enemyState = EnemyState.Attack;
				Debug.DrawLine(transform.position, hit.point, Color.green);
			}
			//STATE TRANSITION: IDLE
			else {
				enemyState = EnemyState.Idle;
				Debug.DrawLine(transform.position, hit.point, Color.red);
			}
		}
	}

	//Logical Behaviours
	void EnemyBehaviour(){
		switch (enemyState) {
		case EnemyState.Idle:
			//Idle
			break;	

		case EnemyState.Attack:
			Attack ();
			break;
		}
	}

	//Behaviour - Attacking
	void Attack(){
		agent.SetDestination (target.transform.position);
	}


	void OnCollisionEnter(Collision otherObject){

		if (otherObject.transform.gameObject.tag == "Player" && Time.time > damageTimer) {
			otherObject.transform.GetComponent<Entity>().takeDamage (damage);
			damageTimer = Time.time + damageInterval;
		}
	}

	public override void takeDamage(float dmg){
		
		health -= dmg;

		
		if (health <= 0) {
			gameManager.AddPoints (points);
			Destroy (this.gameObject);
		}
	}
}
