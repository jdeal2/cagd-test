using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    /*
     * Moving Platform
     *      When standing on the platform, the character should stay on it/move relative to the moving platform
     *      When not standing on the platform, revert to normal behavior
     * Enemy
     *      If the character touches the enemy, he should "die"
     *      
     * 
     * 
     * 
     * Variables you might want:
     *      References to the CharacterController and Keyboard input classes
     *      Speed values for moving, falling, and jumping
     *      A value to keep track of the player's movement speed and direction
     *      You will probably need to use the Update function as well as create functions for moving platforms and enemies
     */

	public float speed = 9f;
	public float gravity = 1.5f;
	public float jumpSpeed = 30f;

	private CharacterController controller;
	private KeyboardInput input;
	private Vector3 moveDir;
	private bool grounded;

	void Start(){
		controller = GetComponent<CharacterController> ();
		input = GetComponent<KeyboardInput> ();
		moveDir = new Vector3 (0f, 0f, 0f);
		grounded = false;
	}

	void Update(){
		moveDir.x = Input.GetAxis("Horizontal") * speed;

		if (input.JumpButtonPressed && this.grounded == true) {
			moveDir.y = jumpSpeed;
			this.grounded = false;
		}
		
		if (!controller.isGrounded) {
			moveDir.y -= gravity;
		}
		else {
			moveDir.y = 0;
			this.grounded = true;
		}
		
		controller.Move (moveDir * Time.deltaTime);
	}

	void OnControllerColliderHit(ControllerColliderHit other){
		transform.SetParent (other.transform);
	}

}