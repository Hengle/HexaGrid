using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	public static float gravity = 9.8f;

	public string KEY_ForwardBackward = "Vertical";
	public string KEY_LeftRight = "Horizontal";
	public string KEY_Turn = "Turn";
	public string KEY_Jump = "Jump";
	
	public float walkSpeed;
	public float jumpPower;
	
	float localgravity;
	
	CharacterController charController;
	[HideInInspector]
	public Vector3 moveDirection = Vector3.zero;

	Transform camTransform;

	void Start()
	{
		charController = GetComponent<CharacterController>();
		camTransform = Camera.main.transform;
	}
	
	void Update() 
	{
		moveDirection = Vector3.zero;
		moveDirection += camTransform.forward * walkSpeed * Input.GetAxis(KEY_ForwardBackward);
		moveDirection += camTransform.right * walkSpeed * Input.GetAxis(KEY_LeftRight);

		transform.LookAt(transform.position + moveDirection);
		Vector3 v3t = transform.eulerAngles;
		v3t.x = v3t.z = 0.0f;
		transform.eulerAngles = v3t;

		if (charController.isGrounded && Input.GetButton(KEY_Jump))
			localgravity = jumpPower;
		
		localgravity -= gravity * Time.deltaTime;
		moveDirection.y = localgravity;
		charController.Move(moveDirection * Time.deltaTime);
	}
}
