using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/CameraControllerFly")]
public class CameraControllerFly : MonoBehaviour 
{
		
	// Use this for initialization
	void Start () 
	{
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
	
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	
	public float sensitivityX = 4.0F;
	public float sensitivityY = 4.0F;
 
	public float minimumX = -360F;
	public float maximumX = 360F;
 
	public float minimumY = -60F;
	public float maximumY = 60F;
 
	public float MoveSpeed = 2.0f;
	
	float rotationY = 0F;
	
	// Update is called once per frame
	void Update () 
	{

		float localSpeed = MoveSpeed * (Input.GetKey(KeyCode.LeftShift) ? 2.0f : 1.0f);
		// Movement
		if (Input.GetKey(KeyCode.W))
		{
			gameObject.transform.position += gameObject.transform.forward * localSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S))
		{
			gameObject.transform.position += gameObject.transform.forward * -localSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A))
		{
			gameObject.transform.position += gameObject.transform.right * -localSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D))
		{
			gameObject.transform.position += gameObject.transform.right * localSpeed * Time.deltaTime;
		}
		
		if (axes == RotationAxes.MouseXAndY)
		{
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}		
	}
}
