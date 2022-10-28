using UnityEngine;

public class Rotator : MonoBehaviour
{
	public float rotationSpeed = 150.0f;

	// Start is called before the first frame update
	private void Start()
	{
		//Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	private void Update()
	{
		if (Input.GetMouseButton(0))
		{
			float mouseX = Input.GetAxisRaw("Mouse X");
			transform.Rotate(0.0f, -mouseX * rotationSpeed * Time.deltaTime, 0.0f);
		}
	}
}
