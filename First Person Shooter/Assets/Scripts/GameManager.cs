using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float mouseSensitivity = 5.0f;

	public bool yInvert = false;

	public int points = 0;
	public int multiplier = 1;
	private float multiplierTimer;
	private float multiplierInterval = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddPoints(int enemyPoints){

		if (Time.time > multiplierTimer) 
			multiplier = 1;
		else if (multiplierTimer > Time.time)
			++multiplier;

		points += enemyPoints * multiplier;
		multiplierTimer = Time.time + multiplierInterval;
	}
}
