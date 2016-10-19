using UnityEngine;
using System.Collections;

public class Player : Entity {

	public GameObject focusPoint;

	public int currentAmmo = 30;

	public bool reloading = false;

	public GameObject[] weapons;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (reloading == false)
			ChangeWeapons ();
	}

	void ChangeWeapons (){
		if(Input.GetKeyDown ("1")){
			weapons[0].SetActive (true);
			weapons[1].SetActive (false);
			currentAmmo = 30;
		} else if(Input.GetKeyDown ("2")){
			weapons[0].SetActive (false);
			weapons[1].SetActive (true);
			currentAmmo = 1;
		} 
	}
}
