using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovment : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private float jumpForce;
	[SerializeField] private float rayCastDistance;


	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	private void FixedUpdate(){
		Move();
	}

	private void Move(){
		float hAxis = Input.GetAxisRaw("Horizontal");
		float vAxis = Input.GetAxisRaw("Vertical");

		Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed;

		Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);

		rb.MovePosition(newPosition);
	}

	// Update is called once per frame
	private void Update () {
		Jump();
	}

	private void Jump(){
		if(Input.GetKeyDown(KeyCode.Space)){
			if(isGrounded()){
				rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
			}
		}
	}

	private bool isGrounded(){
		// Debug.DrawRay(transform.position, Vector3.down * rayCastDistance, Color.blue);
		return Physics.Raycast(transform.position, Vector3.down, rayCastDistance);
	}
}
