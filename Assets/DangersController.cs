using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DangersController : MonoBehaviour {
	public GameObject danger;
	public PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>();	
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Spawn() {
		Instantiate(danger, transform);
	}


}
