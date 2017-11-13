using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SimpleMove : MonoBehaviour {
	public Vector2 myVelocity;
	bool isMoving;
	PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>();	
	}
	
	// Update is called once per frame
	void Update () {
		if (!isMoving && thePlayer.canMove == false) {
			isMoving = true;
			transform.DOMove(myVelocity, 1, false).SetRelative(true).OnComplete(SetCanMove);
		}
	}

	void SetCanMove() {
		thePlayer.canMove = true;
		isMoving = false;
	}
}
