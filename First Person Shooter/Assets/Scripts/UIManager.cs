using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	GameManager gameManager;

	public Text points;
	public Text multiplier;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		points.text = "Points: " + gameManager.points;
		multiplier.text = "Multiplier: " + gameManager.multiplier + "x";
	}
}
