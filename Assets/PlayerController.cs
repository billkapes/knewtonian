using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour {
	public enum direction
	{
		left,right,up,down
	}
	public bool canMove;
	public Vector3 turnVelocity;
	public GameObject leftFire, rightFire, downFire, upFire, bolt1, bolt2, bolt3;
	public int charges, moveCount;
	LineRenderer theLR;
	DangersController theDangers;

	// Use this for initialization
	void Start () {
		theDangers = FindObjectOfType<DangersController>();
		canMove = true;
		theLR = GetComponent<LineRenderer> ();
		bolt1.SetActive(false);
		bolt2.SetActive(false);
		bolt3.SetActive(false);
		charges = 0;
		UpdateCharges();
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove && Input.GetKeyDown(KeyCode.RightArrow)) {
			canMove = false;
			leftFire.SetActive (true);
			leftFire.transform.localScale = Vector3.one + Vector3.one * charges;
			turnVelocity += Vector3.right + Vector3.right * charges;
			transform.DOMove (new Vector3 (transform.position.x + turnVelocity.x + charges, transform.position.y + turnVelocity.y), 1, false).OnComplete(ResetCanMove);
			charges = 0;
			UpdateCharges();
			
		}
		if (canMove && Input.GetKeyDown(KeyCode.LeftArrow)) {
			canMove = false;
			turnVelocity += Vector3.left + Vector3.left * charges;
			rightFire.SetActive (true);
			rightFire.transform.localScale = Vector3.one + Vector3.one * charges;
			transform.DOMove (new Vector3 (transform.position.x + turnVelocity.x - charges, transform.position.y + turnVelocity.y), 1, false).OnComplete(ResetCanMove);
			charges = 0;
			UpdateCharges();
		}
		if (canMove && Input.GetKeyDown(KeyCode.DownArrow)) {
			canMove = false;
			upFire.SetActive (true);
			upFire.transform.localScale = Vector3.one + Vector3.one * charges;
			turnVelocity += Vector3.down + Vector3.down * charges;
			transform.DOMove (new Vector3 (transform.position.x + turnVelocity.x, transform.position.y + turnVelocity.y - charges), 1, false).OnComplete(ResetCanMove);
			charges = 0;
			UpdateCharges();
		}
		if (canMove && Input.GetKeyDown(KeyCode.UpArrow)) {
			canMove = false;
			downFire.SetActive (true);
			downFire.transform.localScale = Vector3.one + Vector3.one * charges;
			turnVelocity += Vector3.up + Vector3.up * charges;
			transform.DOMove (new Vector3 (transform.position.x + turnVelocity.x, transform.position.y + turnVelocity.y + charges), 1, false).OnComplete(ResetCanMove);
			charges = 0;
			UpdateCharges();
		}
		if (canMove && Input.GetKeyDown(KeyCode.Space)) {
			canMove = false;
			transform.DOMove (new Vector3 (transform.position.x + turnVelocity.x, transform.position.y + turnVelocity.y), 1, false).OnComplete(ResetCanMove);
			charges += 1;
			if (charges > 3)
				charges = 3;
			UpdateCharges();
				
		}


	}
	void UpdateCharges() {
		switch (charges) {
		case 0:
			bolt1.SetActive(false);
			bolt2.SetActive(false);
			bolt3.SetActive(false);
			break;
		case 1:
			bolt1.SetActive(true);
			bolt2.SetActive(false);
			bolt3.SetActive(false);
			break;
		case 2:
			bolt1.SetActive(true);
			bolt2.SetActive(true);
			bolt3.SetActive(false);
			break;
		case 3:
			bolt1.SetActive(true);
			bolt2.SetActive(true);
			bolt3.SetActive(true);
			break;
		default:
			break;
		}
	}

	void ResetCanMove() {
		//canMove = true;
		moveCount++;
		if (moveCount % 3 == 0) {
			theDangers.Spawn();
		}
		rightFire.SetActive (false);
		leftFire.SetActive (false);
		upFire.SetActive (false);
		downFire.SetActive (false);
		theLR.SetPosition (0, transform.position);
		theLR.SetPosition (1, transform.position + turnVelocity);
		if (FindObjectOfType<SimpleMove>() == null) {
			canMove = true;
		}
	}
}