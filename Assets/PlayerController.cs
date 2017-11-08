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
	public GameObject leftFire, rightFire, downFire, upFire;

	LineRenderer theLR;

	// Use this for initialization
	void Start () {
		canMove = true;
		theLR = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove && Input.GetKeyDown(KeyCode.RightArrow)) {
			canMove = false;
			leftFire.SetActive (true);
			turnVelocity += Vector3.right;
			transform.DOMove (new Vector3 (transform.position.x + turnVelocity.x, transform.position.y + turnVelocity.y), 1, false).OnComplete(ResetCanMove);
			
		}
		if (canMove && Input.GetKeyDown(KeyCode.LeftArrow)) {
			canMove = false;
			turnVelocity += Vector3.left;
			rightFire.SetActive (true);
			transform.DOMove (new Vector3 (transform.position.x + turnVelocity.x, transform.position.y + turnVelocity.y), 1, false).OnComplete(ResetCanMove);

		}
		if (canMove && Input.GetKeyDown(KeyCode.DownArrow)) {
			canMove = false;
			upFire.SetActive (true);
			turnVelocity += Vector3.down;
			transform.DOMove (new Vector3 (transform.position.x + turnVelocity.x, transform.position.y + turnVelocity.y), 1, false).OnComplete(ResetCanMove);

		}
		if (canMove && Input.GetKeyDown(KeyCode.UpArrow)) {
			canMove = false;
			downFire.SetActive (true);
			turnVelocity += Vector3.up;
			transform.DOMove (new Vector3 (transform.position.x + turnVelocity.x, transform.position.y + turnVelocity.y), 1, false).OnComplete(ResetCanMove);

		}
		if (canMove && Input.GetKeyDown(KeyCode.Space)) {
			transform.DOMove (new Vector3 (transform.position.x + turnVelocity.x, transform.position.y + turnVelocity.y), 1, false).OnComplete(ResetCanMove);
				
		}


	}

	void ResetCanMove() {
		canMove = true;
		rightFire.SetActive (false);
		leftFire.SetActive (false);
		upFire.SetActive (false);
		downFire.SetActive (false);
		theLR.SetPosition (0, transform.position);
		theLR.SetPosition (1, transform.position + turnVelocity);
	}
}